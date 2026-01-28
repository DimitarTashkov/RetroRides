namespace RetroRides.Forms
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            formPanel = new Panel();
            pfpErrorMessages = new Label();
            ageErrors = new Label();
            emailErrors = new Label();
            passwordErrors = new Label();
            usernameErrors = new Label();
            disclaimer = new Label();
            navigationButton = new Button();
            profilePicture = new RetroRides.Utilities.RoundPictureBox();
            registerButton = new Button();
            uploadButton = new Button();
            ageField = new TextBox();
            ageLabel = new Label();
            emailField = new TextBox();
            emailLabel = new Label();
            passwordField = new TextBox();
            passwordLabel = new Label();
            usernameField = new TextBox();
            usernameLabel = new Label();
            logo = new PictureBox();
            register_label = new Label();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.BackColor = SystemColors.Control;
            resources.ApplyResources(formPanel, "formPanel");
            formPanel.Controls.Add(pfpErrorMessages);
            formPanel.Controls.Add(ageErrors);
            formPanel.Controls.Add(emailErrors);
            formPanel.Controls.Add(passwordErrors);
            formPanel.Controls.Add(usernameErrors);
            formPanel.Controls.Add(disclaimer);
            formPanel.Controls.Add(navigationButton);
            formPanel.Controls.Add(profilePicture);
            formPanel.Controls.Add(registerButton);
            formPanel.Controls.Add(uploadButton);
            formPanel.Controls.Add(ageField);
            formPanel.Controls.Add(ageLabel);
            formPanel.Controls.Add(emailField);
            formPanel.Controls.Add(emailLabel);
            formPanel.Controls.Add(passwordField);
            formPanel.Controls.Add(passwordLabel);
            formPanel.Controls.Add(usernameField);
            formPanel.Controls.Add(usernameLabel);
            formPanel.Controls.Add(logo);
            formPanel.Controls.Add(register_label);
            formPanel.Name = "formPanel";
            formPanel.Paint += formPanel_Paint;
            // 
            // pfpErrorMessages
            // 
            resources.ApplyResources(pfpErrorMessages, "pfpErrorMessages");
            pfpErrorMessages.BackColor = Color.Transparent;
            pfpErrorMessages.ForeColor = Color.Red;
            pfpErrorMessages.Name = "pfpErrorMessages";
            // 
            // ageErrors
            // 
            resources.ApplyResources(ageErrors, "ageErrors");
            ageErrors.BackColor = Color.Transparent;
            ageErrors.ForeColor = Color.Red;
            ageErrors.Name = "ageErrors";
            // 
            // emailErrors
            // 
            resources.ApplyResources(emailErrors, "emailErrors");
            emailErrors.BackColor = Color.Transparent;
            emailErrors.ForeColor = Color.Red;
            emailErrors.Name = "emailErrors";
            // 
            // passwordErrors
            // 
            resources.ApplyResources(passwordErrors, "passwordErrors");
            passwordErrors.BackColor = Color.Transparent;
            passwordErrors.ForeColor = Color.Red;
            passwordErrors.Name = "passwordErrors";
            // 
            // usernameErrors
            // 
            resources.ApplyResources(usernameErrors, "usernameErrors");
            usernameErrors.BackColor = Color.Transparent;
            usernameErrors.ForeColor = Color.Red;
            usernameErrors.Name = "usernameErrors";
            // 
            // disclaimer
            // 
            resources.ApplyResources(disclaimer, "disclaimer");
            disclaimer.BackColor = Color.Transparent;
            disclaimer.ForeColor = Color.DimGray;
            disclaimer.Name = "disclaimer";
            // 
            // navigationButton
            // 
            navigationButton.BackColor = Color.DarkOrange;
            resources.ApplyResources(navigationButton, "navigationButton");
            navigationButton.Name = "navigationButton";
            navigationButton.UseVisualStyleBackColor = false;
            navigationButton.Click += navigationButton_Click;
            // 
            // profilePicture
            // 
            resources.ApplyResources(profilePicture, "profilePicture");
            profilePicture.Name = "profilePicture";
            profilePicture.TabStop = false;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.LightGreen;
            resources.ApplyResources(registerButton, "registerButton");
            registerButton.Name = "registerButton";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += btnRegister_Click;
            // 
            // uploadButton
            // 
            resources.ApplyResources(uploadButton, "uploadButton");
            uploadButton.Name = "uploadButton";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadImage_click;
            // 
            // ageField
            // 
            ageField.BackColor = Color.LightGray;
            resources.ApplyResources(ageField, "ageField");
            ageField.ForeColor = Color.DimGray;
            ageField.Name = "ageField";
            // 
            // ageLabel
            // 
            resources.ApplyResources(ageLabel, "ageLabel");
            ageLabel.BackColor = Color.Transparent;
            ageLabel.Name = "ageLabel";
            // 
            // emailField
            // 
            emailField.BackColor = Color.LightGray;
            resources.ApplyResources(emailField, "emailField");
            emailField.ForeColor = Color.DimGray;
            emailField.Name = "emailField";
            // 
            // emailLabel
            // 
            resources.ApplyResources(emailLabel, "emailLabel");
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Name = "emailLabel";
            // 
            // passwordField
            // 
            passwordField.BackColor = Color.LightGray;
            resources.ApplyResources(passwordField, "passwordField");
            passwordField.ForeColor = Color.DimGray;
            passwordField.Name = "passwordField";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Name = "passwordLabel";
            // 
            // usernameField
            // 
            usernameField.BackColor = Color.LightGray;
            resources.ApplyResources(usernameField, "usernameField");
            usernameField.ForeColor = Color.DimGray;
            usernameField.Name = "usernameField";
            // 
            // usernameLabel
            // 
            resources.ApplyResources(usernameLabel, "usernameLabel");
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Name = "usernameLabel";
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            resources.ApplyResources(logo, "logo");
            logo.Name = "logo";
            logo.TabStop = false;
            // 
            // register_label
            // 
            resources.ApplyResources(register_label, "register_label");
            register_label.BackColor = Color.Transparent;
            register_label.Name = "register_label";
            // 
            // Register
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(formPanel);
            Name = "Register";
            Load += Register_Load;
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel formPanel;
        private Label disclaimer;
        private Button navigationButton;
        private RetroRides.Utilities.RoundPictureBox profilePicture;
        private Button registerButton;
        private Button uploadButton;
        private TextBox ageField;
        private Label ageLabel;
        private TextBox emailField;
        private Label emailLabel;
        private TextBox passwordField;
        private Label passwordLabel;
        private TextBox usernameField;
        private Label usernameLabel;
        private PictureBox logo;
        private Label register_label;
        private Label usernameErrors;
        private Label ageErrors;
        private Label emailErrors;
        private Label passwordErrors;
        private Label pfpErrorMessages;
    }
}