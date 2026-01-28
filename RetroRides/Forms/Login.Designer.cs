namespace RetroRides.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            formPanel = new Panel();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            passwordError = new Label();
            usernameError = new Label();
            register = new Label();
            loginBtn = new Button();
            passwordField = new TextBox();
            passwordLabel = new Label();
            usernameField = new TextBox();
            usernameLabel = new Label();
            logo = new PictureBox();
            label3 = new Label();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.BackColor = Color.White;
            formPanel.BackgroundImage = Properties.Resources.gradient_img__4_;
            resources.ApplyResources(formPanel, "formPanel");
            formPanel.Controls.Add(label8);
            formPanel.Controls.Add(label7);
            formPanel.Controls.Add(label4);
            formPanel.Controls.Add(label6);
            formPanel.Controls.Add(label2);
            formPanel.Controls.Add(label1);
            formPanel.Controls.Add(passwordError);
            formPanel.Controls.Add(usernameError);
            formPanel.Controls.Add(register);
            formPanel.Controls.Add(loginBtn);
            formPanel.Controls.Add(passwordField);
            formPanel.Controls.Add(passwordLabel);
            formPanel.Controls.Add(usernameField);
            formPanel.Controls.Add(usernameLabel);
            formPanel.Controls.Add(logo);
            formPanel.Name = "formPanel";
            formPanel.Paint += formPanel_Paint;
            // 
            // label8
            // 
            label8.AllowDrop = true;
            label8.BackColor = Color.Transparent;
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = Color.Goldenrod;
            label8.Name = "label8";
            // 
            // label7
            // 
            label7.AllowDrop = true;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.Goldenrod;
            label7.Name = "label7";
            // 
            // label4
            // 
            label4.AllowDrop = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Goldenrod;
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label6
            // 
            label6.AllowDrop = true;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.Goldenrod;
            label6.Name = "label6";
            // 
            // label2
            // 
            label2.AllowDrop = true;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Goldenrod;
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.Name = "label1";
            // 
            // passwordError
            // 
            resources.ApplyResources(passwordError, "passwordError");
            passwordError.BackColor = Color.Transparent;
            passwordError.ForeColor = Color.Red;
            passwordError.Name = "passwordError";
            // 
            // usernameError
            // 
            resources.ApplyResources(usernameError, "usernameError");
            usernameError.BackColor = Color.Transparent;
            usernameError.ForeColor = Color.Red;
            usernameError.Name = "usernameError";
            // 
            // register
            // 
            resources.ApplyResources(register, "register");
            register.BackColor = Color.Transparent;
            register.Cursor = Cursors.Hand;
            register.ForeColor = Color.Blue;
            register.Name = "register";
            register.Click += register_Click;
            register.MouseLeave += register_leave;
            register.MouseHover += register_hover;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.SkyBlue;
            resources.ApplyResources(loginBtn, "loginBtn");
            loginBtn.ForeColor = Color.Black;
            loginBtn.Name = "loginBtn";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += login_Click;
            loginBtn.MouseLeave += login_leave;
            loginBtn.MouseHover += login_hover;
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
            logo.BackgroundImage = Properties.Resources.RetroRides_logo;
            resources.ApplyResources(logo, "logo");
            logo.Name = "logo";
            logo.TabStop = false;
            // 
            // label3
            // 
            label3.AllowDrop = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Goldenrod;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            Controls.Add(formPanel);
            Controls.Add(label3);
            DoubleBuffered = true;
            Name = "Login";
            Load += Login_Load;
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel formPanel;
        private Label register;
        private Button loginBtn;
        private TextBox passwordField;
        private Label passwordLabel;
        private TextBox usernameField;
        private Label usernameLabel;
        private PictureBox logo;
        private Label usernameError;
        private Label passwordError;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label6;
        private Label label4;
        private Label label8;
        private Label label7;
    }
}