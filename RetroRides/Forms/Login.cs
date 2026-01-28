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

        public Login(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
            usernameField.TextChanged += EventsEffects.input_TextChanged;
            usernameField.Click += EventsEffects.clearInputs_click;
            passwordField.TextChanged += EventsEffects.input_TextChanged;
            passwordField.Click += EventsEffects.clearInputs_click;
            passwordField.PasswordChar = '*';
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

    }
}
