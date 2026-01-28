namespace RetroRides.Forms
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            usersContainer = new FlowLayoutPanel();
            usersHeaders = new FlowLayoutPanel();
            usernameHeader = new Label();
            passwordHeader = new Label();
            emailHeader = new Label();
            ageHeader = new Label();
            avatarHeader = new Label();
            label1 = new Label();
            dateHeader = new Label();
            arriveHeader = new Label();
            roundPictureBox1 = new RetroRides.Utilities.RoundPictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            User = new ToolStripMenuItem();
            Management = new ToolStripMenuItem();
            manageProducts = new ToolStripMenuItem();
            manageServices = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            usersContainer.SuspendLayout();
            usersHeaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // usersContainer
            // 
            resources.ApplyResources(usersContainer, "usersContainer");
            usersContainer.Controls.Add(usersHeaders);
            usersContainer.Name = "usersContainer";
            // 
            // usersHeaders
            // 
            usersHeaders.BackColor = Color.Cyan;
            usersHeaders.Controls.Add(usernameHeader);
            usersHeaders.Controls.Add(passwordHeader);
            usersHeaders.Controls.Add(emailHeader);
            usersHeaders.Controls.Add(ageHeader);
            usersHeaders.Controls.Add(avatarHeader);
            usersHeaders.Controls.Add(label1);
            usersHeaders.Controls.Add(dateHeader);
            usersHeaders.Controls.Add(arriveHeader);
            resources.ApplyResources(usersHeaders, "usersHeaders");
            usersHeaders.Name = "usersHeaders";
            // 
            // usernameHeader
            // 
            resources.ApplyResources(usernameHeader, "usernameHeader");
            usernameHeader.BackColor = Color.Transparent;
            usernameHeader.Name = "usernameHeader";
            // 
            // passwordHeader
            // 
            resources.ApplyResources(passwordHeader, "passwordHeader");
            passwordHeader.BackColor = Color.Transparent;
            passwordHeader.Name = "passwordHeader";
            // 
            // emailHeader
            // 
            resources.ApplyResources(emailHeader, "emailHeader");
            emailHeader.BackColor = Color.Transparent;
            emailHeader.Name = "emailHeader";
            // 
            // ageHeader
            // 
            resources.ApplyResources(ageHeader, "ageHeader");
            ageHeader.BackColor = Color.Transparent;
            ageHeader.Name = "ageHeader";
            // 
            // avatarHeader
            // 
            resources.ApplyResources(avatarHeader, "avatarHeader");
            avatarHeader.BackColor = Color.Transparent;
            avatarHeader.Name = "avatarHeader";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.Name = "label1";
            // 
            // dateHeader
            // 
            resources.ApplyResources(dateHeader, "dateHeader");
            dateHeader.Name = "dateHeader";
            // 
            // arriveHeader
            // 
            resources.ApplyResources(arriveHeader, "arriveHeader");
            arriveHeader.Name = "arriveHeader";
            // 
            // roundPictureBox1
            // 
            resources.ApplyResources(roundPictureBox1, "roundPictureBox1");
            roundPictureBox1.Name = "roundPictureBox1";
            roundPictureBox1.TabStop = false;
            roundPictureBox1.Click += roundPictureBox1_Click;
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ScrollBar;
            resources.ApplyResources(menu, "menu");
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { Home, Store, Services, User, Management, MyReservations });
            menu.Name = "menu";
            // 
            // Home
            // 
            Home.Name = "Home";
            resources.ApplyResources(Home, "Home");
            // 
            // Store
            // 
            Store.ForeColor = SystemColors.ActiveCaptionText;
            Store.Name = "Store";
            Store.Padding = new Padding(4, 0, 4, 5);
            resources.ApplyResources(Store, "Store");
            // 
            // Services
            // 
            Services.ForeColor = SystemColors.ActiveCaptionText;
            Services.Name = "Services";
            Services.Padding = new Padding(4, 0, 4, 5);
            resources.ApplyResources(Services, "Services");
            // 
            // User
            // 
            resources.ApplyResources(User, "User");
            User.ForeColor = SystemColors.MenuText;
            User.Name = "User";
            User.Padding = new Padding(4, 0, 4, 5);
            // 
            // Management
            // 
            Management.DropDownItems.AddRange(new ToolStripItem[] { manageProducts, manageServices });
            resources.ApplyResources(Management, "Management");
            Management.Name = "Management";
            // 
            // manageProducts
            // 
            manageProducts.Name = "manageProducts";
            resources.ApplyResources(manageProducts, "manageProducts");
            // 
            // manageServices
            // 
            manageServices.Name = "manageServices";
            resources.ApplyResources(manageServices, "manageServices");
            // 
            // MyReservations
            // 
            resources.ApplyResources(MyReservations, "MyReservations");
            MyReservations.ForeColor = SystemColors.ActiveCaptionText;
            MyReservations.Name = "MyReservations";
            MyReservations.Padding = new Padding(4, 0, 4, 5);
            // 
            // Users
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPictureBox1);
            Controls.Add(menu);
            Controls.Add(usersContainer);
            Name = "Users";
            Load += Users_Load;
            usersContainer.ResumeLayout(false);
            usersHeaders.ResumeLayout(false);
            usersHeaders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel usersContainer;
        private FlowLayoutPanel usersHeaders;
        private Label usernameHeader;
        private Label passwordHeader;
        private Label emailHeader;
        private Label ageHeader;
        private Label avatarHeader;
        private Label label1;
        private Label dateHeader;
        private Label arriveHeader;
        private Utilities.RoundPictureBox roundPictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Home;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem User;
        private ToolStripMenuItem Management;
        private ToolStripMenuItem manageProducts;
        private ToolStripMenuItem manageServices;
        private ToolStripMenuItem MyReservations;
    }
}