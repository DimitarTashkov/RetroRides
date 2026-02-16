using RetroRides.Utilities;
using RetroRides.DTOs.User;
using RetroRides.Services.Interfaces;
using static RetroRides.Common.Constants.ValidationConstants.UserConstants;
using static RetroRides.Common.Constants.ValidationConstants.InputConstants;
using static RetroRides.Utilities.DynamicContentTranslator.EntitiesTranslation;
using RetroRides;


namespace RetroRides.Forms
{
    public partial class Register : Form
    {
        private readonly IUserService userService;
        private bool isMobileView = false;
        private Size originalFormSize;
        private Size originalPanelSize;
        private Point originalPanelLocation;
        private Dictionary<Control, (Point Location, Size Size, Font Font, bool Visible)> originalStates;

        public Register(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;

            originalFormSize = this.ClientSize;
            originalPanelSize = formPanel.Size;
            originalPanelLocation = formPanel.Location;

            usernameField.TextChanged += EventsEffects.input_TextChanged;
            usernameField.Click += EventsEffects.clearInputs_click;
            passwordField.TextChanged += EventsEffects.input_TextChanged;
            passwordField.Click += EventsEffects.clearInputs_click;
            emailField.TextChanged += EventsEffects.input_TextChanged;
            emailField.Click += EventsEffects.clearInputs_click;
            ageField.TextChanged += EventsEffects.input_TextChanged;
            ageField.Click += EventsEffects.clearInputs_click;

            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Cursor = Cursors.Hand;

            ApplyStyles();

            // Save AFTER ApplyStyles so restored state includes styled fonts
        }


        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);

            usernameField.Font = new Font("Segoe UI", 10);
            passwordField.Font = new Font("Segoe UI", 10);
            emailField.Font = new Font("Segoe UI", 10);
            ageField.Font = new Font("Segoe UI", 10);
            usernameField.BackColor = Color.White;
            passwordField.BackColor = Color.White;
            emailField.BackColor = Color.White;
            ageField.BackColor = Color.White;
            usernameField.BorderStyle = BorderStyle.FixedSingle;
            passwordField.BorderStyle = BorderStyle.FixedSingle;
            emailField.BorderStyle = BorderStyle.FixedSingle;
            ageField.BorderStyle = BorderStyle.FixedSingle;

            registerButton.BackColor = Color.FromArgb(39, 174, 96);
            registerButton.ForeColor = Color.White;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            registerButton.MouseEnter += (s, e) => registerButton.BackColor = Color.FromArgb(33, 154, 82);
            registerButton.MouseLeave += (s, e) => registerButton.BackColor = Color.FromArgb(39, 174, 96);

            navigationButton.BackColor = Color.FromArgb(149, 165, 166);
            navigationButton.ForeColor = Color.White;
            navigationButton.FlatStyle = FlatStyle.Flat;
            navigationButton.FlatAppearance.BorderSize = 0;
            navigationButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            navigationButton.MouseEnter += (s, e) => navigationButton.BackColor = Color.FromArgb(127, 140, 141);
            navigationButton.MouseLeave += (s, e) => navigationButton.BackColor = Color.FromArgb(149, 165, 166);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
        private void uploadImage_click(Object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = DialogFilter;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                }
                profilePicture.ImageLocation = imageLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(EmptyOrInvalidImage, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            registerButton.BackColor = Color.DarkGreen;

            List<TextBox> inputs = new List<TextBox>
            {
                usernameField,
                passwordField,
                emailField
            };
            bool areInputsValid = ValidationHelper.ValidateUserInputs(inputs, profilePicture);
            if (!areInputsValid)
            {
                MessageBox.Show(EmptyInputData, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = usernameField.Text.Trim();
            string password = passwordField.Text.Trim();
            string email = emailField.Text.Trim();
            string avatarUrl = profilePicture.ImageLocation;
            int age = ValidationHelper.ValidateUserAge(ageField);

            var registrationModel = new RegisterUserInputModel
            {
                Username = username,
                Password = password,
                Email = email,
                AvatarUrl = avatarUrl,
                Age = age
            };

            var (isValid, errors) = await userService.ValidateModelAsync(registrationModel);

            if (!isValid)
            {
                foreach (var error in errors)
                {
                    if (error.MemberNames.Contains(nameof(registrationModel.Username)))
                    {
                        usernameErrors.Text = string.Format(FieldLength, Username, NameMinLength);
                        usernameErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(registrationModel.Password)))
                    {
                        passwordErrors.Text = string.Format(FieldLength, Password, PasswordMinLength);
                        passwordErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(registrationModel.Email)))
                    {
                        emailErrors.Text = error.ErrorMessage;
                        emailErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(registrationModel.AvatarUrl)))
                    {
                        pfpErrorMessages.Text = error.ErrorMessage;
                        pfpErrorMessages.Visible = true;
                    }
                }
                return;
            }
            if (await userService.IsUsernameTaken(username))
            {
                MessageBox.Show(UsernameExists, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await userService.RegisterUserAsync(registrationModel);

            MessageBox.Show(ProfileRegistered, Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login login = new Login(userService);
            Program.SwitchMainForm(login);
        }

        private void navigationButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login(userService);
            Program.SwitchMainForm(loginForm);
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
                Register register = new Register(userService);
                Program.SwitchMainForm(register);
            }

            this.CenterToScreen();
        }

        private void ApplyMobileLayout()
        {
            int mobileWidth = 250;
            int padding = 10;
            int fieldWidth = mobileWidth - padding * 2;
            int y = padding;

            this.ClientSize = new Size(mobileWidth, 550);
            formPanel.Location = new Point(0, 0);
            formPanel.Size = new Size(mobileWidth, 550);

            // Hide decorative controls in mobile view
            logo.Visible = false;
            register_label.Visible = false;
            disclaimer.Visible = false;
            pfpErrorMessages.Visible = false;
            ageErrors.Visible = false;
            emailErrors.Visible = false;
            passwordErrors.Visible = false;
            usernameErrors.Visible = false;

            Font labelFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fieldFont = new Font("Segoe UI", 9);
            Font btnFont = new Font("Segoe UI", 10, FontStyle.Bold);

            // Username
            usernameLabel.Location = new Point(padding, y);
            usernameLabel.Size = new Size(fieldWidth, 22);
            usernameLabel.Font = labelFont;
            y += 24;
            usernameField.Location = new Point(padding, y);
            usernameField.Size = new Size(fieldWidth, 24);
            usernameField.Font = fieldFont;
            y += 30;

            // Password
            passwordLabel.Location = new Point(padding, y);
            passwordLabel.Size = new Size(fieldWidth, 22);
            passwordLabel.Font = labelFont;
            y += 24;
            passwordField.Location = new Point(padding, y);
            passwordField.Size = new Size(fieldWidth, 24);
            passwordField.Font = fieldFont;
            y += 30;

            // Email
            emailLabel.Location = new Point(padding, y);
            emailLabel.Size = new Size(fieldWidth, 22);
            emailLabel.Font = labelFont;
            y += 24;
            emailField.Location = new Point(padding, y);
            emailField.Size = new Size(fieldWidth, 24);
            emailField.Font = fieldFont;
            y += 30;

            // Age
            ageLabel.Location = new Point(padding, y);
            ageLabel.Size = new Size(fieldWidth, 22);
            ageLabel.Font = labelFont;
            y += 24;
            ageField.Location = new Point(padding, y);
            ageField.Size = new Size(fieldWidth, 24);
            ageField.Font = fieldFont;
            y += 30;

            // Profile picture + upload
            profilePicture.Location = new Point(padding, y);
            profilePicture.Size = new Size(60, 60);
            uploadButton.Location = new Point(padding + 70, y + 15);
            uploadButton.Size = new Size(fieldWidth - 70, 30);
            uploadButton.Font = fieldFont;
            y += 70;

            // Register button
            registerButton.Location = new Point(padding, y);
            registerButton.Size = new Size(fieldWidth, 38);
            registerButton.Font = btnFont;
            y += 44;

            // Navigation (back) button
            navigationButton.Location = new Point(padding, y);
            navigationButton.Size = new Size(fieldWidth, 34);
            navigationButton.Font = btnFont;
            y += 42;

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