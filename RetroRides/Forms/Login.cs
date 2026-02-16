using RetroRides.Utilities;
using RetroRides.Common.Constants;
using RetroRides.DTOs.User;
using RetroRides.Models.DbConfiguration;
using RetroRides.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

using static RetroRides.Common.Constants.ValidationConstants.UserConstants;
using static RetroRides.Utilities.DynamicContentTranslator.EntitiesTranslation;

using RetroRides;

namespace RetroRides.Forms
{
    public partial class Login : Form
    {
        private readonly IUserService userService;
        private bool isMobileView = false;
        private Size originalFormSize;
        private Size originalPanelSize;
        private Point originalPanelLocation;
        private Point originalLabel3Location;
        private Size originalLabel3Size;
        private Font originalLabel3Font;
        private bool originalLabel3Visible;
        private Dictionary<Control, (Point Location, Size Size, Font Font, bool Visible)> originalStates;

        public Login(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();

            originalFormSize = this.ClientSize;
            originalPanelSize = formPanel.Size;
            originalPanelLocation = formPanel.Location;
            originalLabel3Location = label3.Location;
            originalLabel3Size = label3.Size;
            originalLabel3Font = label3.Font;
            originalLabel3Visible = label3.Visible;


            usernameField.TextChanged += EventsEffects.input_TextChanged;
            usernameField.Click += EventsEffects.clearInputs_click;
            passwordField.TextChanged += EventsEffects.input_TextChanged;
            passwordField.Click += EventsEffects.clearInputs_click;
            passwordField.PasswordChar = '*';

            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Cursor = Cursors.Hand;
        }



        private void RestoreOriginalStates()
        {
            foreach (var kvp in originalStates)
            {
                kvp.Key.Location = kvp.Value.Location;
                kvp.Key.Size = kvp.Value.Size;
                kvp.Key.Font = kvp.Value.Font;
                kvp.Key.Visible = kvp.Value.Visible;
            }
            label3.Location = originalLabel3Location;
            label3.Size = originalLabel3Size;
            label3.Font = originalLabel3Font;
            label3.Visible = originalLabel3Visible;
        }

        private void register_hover(object sender, EventArgs e)
        {
            register.ForeColor = Color.Indigo;
        }

        private void register_leave(object sender, EventArgs e)
        {
            register.ForeColor = Color.Blue;
        }
        private void register_Click(object sender, EventArgs e)
        {
            register.ForeColor = Color.BlueViolet;
            Register registerForm = new Register(userService);
            Program.SwitchMainForm(registerForm);
        }

        private void login_hover(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.DeepSkyBlue;
        }

        private void login_leave(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.SkyBlue;
            loginBtn.ForeColor = Color.Black;
        }
        private async void login_Click(object sender, EventArgs e)
        {
            List<TextBox> inputs = new List<TextBox>()
            {
                usernameField
                ,passwordField
            };

            bool areInputValid = ValidationHelper.ValidateUserInputs(inputs);
            if (!areInputValid)
            {
                MessageBox.Show(EmptyInputData, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = usernameField.Text.Trim();
            string password = passwordField.Text.Trim();

            var loginModel = new LoginUserInputModel
            {
                Username = username,
                Password = password
            };

            var (isValid, errors) = await userService.ValidateModelAsync(loginModel);

            if (!isValid)
            {
                foreach (var error in errors)
                {
                    if (error.MemberNames.Contains(nameof(loginModel.Username)))
                    {
                        usernameError.Text = string.Format(FieldLength, Username, NameMinLength);
                        usernameError.Visible = true;
                    }

                    if (error.MemberNames.Contains(nameof(loginModel.Password)))
                    {
                        passwordError.Text = string.Format(FieldLength, Password, PasswordMinLength);
                        passwordError.Visible = true;
                    }
                }
                return;
            }

            bool isAuthenticated = await userService.AuthenticateUserAsync(username, password);

            //Not necessary here but it sets the private property so that we dont need to execute it later.
            //It can be executed in the Index form too
            bool isAdmin = await AuthorizationHelper.InitializeAuthorizationStatusAsync(userService);

            if (isAuthenticated)
            {
                Index indexForm = new Index(userService);
                Program.SwitchMainForm(indexForm);
            }
            else
            {
                MessageBox.Show(InvalidUserCredentials, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.ForeColor = Color.Black;
            textBox.Font = FontsPicker.BaseFont;
        }

        private async void Login_Load(object sender, EventArgs e)
        {
            await SeedAdmin.SeedAdminUserAsync();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isMobileView = !isMobileView;

            if (isMobileView)
            {
                ApplyMobileLayout();
            }
            else
            {
                Login login = new Login(userService);
                Program.SwitchMainForm(login);
            }

            this.CenterToScreen();
        }

        private void ApplyMobileLayout()
        {
            int mobileWidth = 250;
            int padding = 10;
            int fieldWidth = mobileWidth - padding * 2;
            int y = padding;

            this.ClientSize = new Size(mobileWidth, 400);
            formPanel.Location = new Point(0, 0);
            formPanel.Size = new Size(mobileWidth, 400);

            // Hide decorative labels and logo in mobile view
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            logo.Visible = false;

            Font labelFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font fieldFont = new Font("Segoe UI", 10);
            Font btnFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font linkFont = new Font("Segoe UI", 9, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

            // Username label
            usernameLabel.Location = new Point(padding, y);
            usernameLabel.Size = new Size(fieldWidth, 25);
            usernameLabel.Font = labelFont;
            y += 28;

            // Username field
            usernameField.Location = new Point(padding, y);
            usernameField.Size = new Size(fieldWidth, 28);
            usernameField.Font = fieldFont;
            y += 32;

            // Username error
            usernameError.Location = new Point(padding, y);
            usernameError.Size = new Size(fieldWidth, 18);
            y += 22;

            // Password label
            passwordLabel.Location = new Point(padding, y);
            passwordLabel.Size = new Size(fieldWidth, 25);
            passwordLabel.Font = labelFont;
            y += 28;

            // Password field
            passwordField.Location = new Point(padding, y);
            passwordField.Size = new Size(fieldWidth, 28);
            passwordField.Font = fieldFont;
            y += 32;

            // Password error
            passwordError.Location = new Point(padding, y);
            passwordError.Size = new Size(fieldWidth, 18);
            y += 28;

            // Login button
            loginBtn.Location = new Point(padding, y);
            loginBtn.Size = new Size(fieldWidth, 42);
            loginBtn.Font = btnFont;
            y += 50;

            // Register link
            register.Location = new Point(padding, y);
            register.Size = new Size(fieldWidth, 22);
            register.Font = linkFont;
            y += 30;

            // Responsive toggle icon
            pictureBox1.Image = Properties.Resources.responsive_initial_image;
            pictureBox1.BackgroundImage = Properties.Resources.responsive_initial_image;
            pictureBox1.Location = new Point(mobileWidth - 40, y);
            pictureBox1.Size = new Size(30, 30);

            this.ClientSize = new Size(mobileWidth, y + 40);
            formPanel.Size = new Size(mobileWidth, y + 40);
        }


        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}