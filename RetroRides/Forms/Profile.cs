using Microsoft.EntityFrameworkCore;
using RetroRides;
using RetroRides.Common.Constants;
using RetroRides.DTOs.User;
using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using RetroRides.Utilities;
using static RetroRides.Common.Constants.ValidationConstants.InputConstants;
using static RetroRides.Common.Constants.ValidationConstants.UserConstants;
using static RetroRides.Utilities.DynamicContentTranslator.EntitiesTranslation;

namespace RetroRides.Forms
{
    public partial class Profile : Form
    {
        private User activeUser;
        private Guid userId;
        private readonly IUserService userService;


        public Profile(IUserService userService, Guid userId)
        {
            InitializeComponent();
            this.userService = userService;
            this.userId = userId;

            ApplyStyles();
        }

        private async Task LoadUserDataAsync()
        {
            activeUser = await userService.FindUserByIdAsync(userId);
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
        }
        private void navigationButton_Click(object sender, EventArgs e)
        {
            Index indexForm = new Index(userService);
            Program.SwitchMainForm(indexForm);
        }

        private void ApplyStyles()
        {
            //this.BackColor = Color.FromArgb(245, 245, 245);
            navigationButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            navigationButton.ForeColor = Color.White;

            // Стилове за текстови полета
            usernameField.Font = new Font("Segoe UI", 11);
            passwordField.Font = new Font("Segoe UI", 11);
            emailField.Font = new Font("Segoe UI", 11);
            ageField.Font = new Font("Segoe UI", 11);
            usernameField.BackColor = Color.White;
            passwordField.BackColor = Color.White;
            emailField.BackColor = Color.White;
            ageField.BackColor = Color.White;
            usernameField.BorderStyle = BorderStyle.FixedSingle;
            passwordField.BorderStyle = BorderStyle.FixedSingle;
            emailField.BorderStyle = BorderStyle.FixedSingle;
            ageField.BorderStyle = BorderStyle.FixedSingle;        

            // Стилове за бутони
            editButton.BackColor = Color.FromArgb(39, 174, 96);
            editButton.ForeColor = Color.White;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            editButton.MouseEnter += (s, e) => editButton.BackColor = Color.FromArgb(33, 154, 82);
            editButton.MouseLeave += (s, e) => editButton.BackColor = Color.FromArgb(39, 174, 96);

            saveButton.BackColor = Color.FromArgb(39, 174, 96);
            saveButton.ForeColor = Color.White;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            saveButton.MouseEnter += (s, e) => saveButton.BackColor = Color.FromArgb(33, 154, 82);
            saveButton.MouseLeave += (s, e) => saveButton.BackColor = Color.FromArgb(39, 174, 96);
            saveButton.Visible = false;

            deleteButton.BackColor = Color.FromArgb(231, 76, 60);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            deleteButton.MouseEnter += (s, e) => deleteButton.BackColor = Color.FromArgb(200, 50, 50);
            deleteButton.MouseLeave += (s, e) => deleteButton.BackColor = Color.FromArgb(231, 76, 60);

            logoutButton.BackColor = Color.FromArgb(149, 165, 166);
            logoutButton.ForeColor = Color.White;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            logoutButton.MouseEnter += (s, e) => logoutButton.BackColor = Color.FromArgb(127, 140, 141);
            logoutButton.MouseLeave += (s, e) => logoutButton.BackColor = Color.FromArgb(149, 165, 166);

            uploadButton.Click += uploadImage_click;

        }

        private async void Profile_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();

            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }

            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;

            usernameField.Text = activeUser.Username;
            passwordField.Text = new string('*', activeUser.Password.Length);
            emailField.Text = activeUser.Email;
            ageField.Text = activeUser.Age.ToString();
            profilePicture.ImageLocation = activeUser.AvatarUrl;

            emailField.ForeColor = Color.DimGray;
            ageField.ForeColor = Color.DimGray;
            usernameField.ForeColor = Color.DimGray;
            passwordField.ForeColor = Color.DimGray;

        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
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

            var editModel = new EditProfileInputModel()
            {
                Id = activeUser.Id,
                Username = usernameField.Text.Trim(),
                Email = emailField.Text.Trim(),
                AvatarUrl = profilePicture.ImageLocation,
                Password = passwordField.Text,
                Age = ValidationHelper.ValidateUserAge(ageField)
            };

            var (isValid, errors) = await userService.ValidateModelAsync(editModel);
            if (!isValid)
            {
                foreach (var error in errors)
                {
                    if (error.MemberNames.Contains(nameof(editModel.Username)))
                    {
                        usernameErrors.Text = string.Format(FieldLength, Username, NameMinLength);
                        usernameErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(editModel.Password)))
                    {
                        passwordErrors.Text = string.Format(FieldLength, Password, PasswordMinLength);
                        passwordErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(editModel.Email)))
                    {
                        emailErrors.Text = string.Format(FieldLength, Password, PasswordMinLength);
                        emailErrors.Visible = true;
                    }
                    if (error.MemberNames.Contains(nameof(editModel.AvatarUrl)))
                    {
                        pfpErrors.Text = ProfilePicture;
                        pfpErrors.Visible = true;
                    }
                }
                return;
            }

            bool success = await userService.UpdateUserAsync(editModel);
            if (success)
            {
                MessageBox.Show(ProfileUpdatedSuccessfully, Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Profile profileForm = new Profile(userService,activeUser.Id);
                Program.SwitchMainForm(profileForm);
            }
            else
            {
                MessageBox.Show(ProfileUpdateFailed, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                return;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = false;
            saveButton.Visible = true;

            usernameField.Enabled = true;
            passwordField.Enabled = true;

            passwordField.Text = activeUser.Password;
            passwordField.ForeColor = Color.DimGray;

            usernameField.Font = FontsPicker.DetailsFont;
            passwordField.Font = FontsPicker.DetailsFont;
            emailField.Font = FontsPicker.DetailsFont;
            ageField.Font = FontsPicker.DetailsFont;


            emailField.Enabled = true;
            ageField.Enabled = true;
            uploadButton.Enabled = true;

            ActiveControl = usernameField;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            userService.LogoutUser();
            Login loginForm = new Login(userService);
            Program.SwitchMainForm(loginForm);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                ProfileDeleteWarning,
                Confirmation,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool isDeleted = await userService.DeleteUserAsync(activeUser.Id);

                if (isDeleted)
                {
                    MessageBox.Show(ProfileDeletionSuccessful, Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login loginForm = new Login(userService);
                    Program.SwitchMainForm(loginForm);
                }
                else
                {
                    MessageBox.Show(ProfileDeletionFailed, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
    }
}