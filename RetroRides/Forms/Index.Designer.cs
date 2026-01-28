namespace RetroRides.Forms
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            footer = new Button();
            storeButton = new Button();
            servicesButton = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Management = new ToolStripMenuItem();
            manageProducts = new ToolStripMenuItem();
            manageServices = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            aboutUs = new Label();
            contactUs = new Label();
            welcomeMessage = new Label();
            roundPictureBox1 = new RetroRides.Utilities.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // footer
            // 
            footer.BackColor = Color.Transparent;
            resources.ApplyResources(footer, "footer");
            footer.Name = "footer";
            footer.UseVisualStyleBackColor = false;
            // 
            // storeButton
            // 
            storeButton.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(storeButton, "storeButton");
            storeButton.Name = "storeButton";
            storeButton.UseVisualStyleBackColor = false;
            // 
            // servicesButton
            // 
            servicesButton.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(servicesButton, "servicesButton");
            servicesButton.Name = "servicesButton";
            servicesButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ScrollBar;
            resources.ApplyResources(menu, "menu");
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { Home, Store, Services, Users, Management, MyReservations });
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
            // Users
            // 
            resources.ApplyResources(Users, "Users");
            Users.ForeColor = SystemColors.MenuText;
            Users.Name = "Users";
            Users.Padding = new Padding(4, 0, 4, 5);
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
            // aboutUs
            // 
            resources.ApplyResources(aboutUs, "aboutUs");
            aboutUs.BackColor = Color.Transparent;
            aboutUs.ForeColor = Color.White;
            aboutUs.Name = "aboutUs";
            aboutUs.Click += aboutUs_Click;
            // 
            // contactUs
            // 
            resources.ApplyResources(contactUs, "contactUs");
            contactUs.BackColor = Color.Transparent;
            contactUs.ForeColor = Color.White;
            contactUs.Name = "contactUs";
            contactUs.Click += contactUs_Click;
            // 
            // welcomeMessage
            // 
            welcomeMessage.BackColor = Color.Transparent;
            resources.ApplyResources(welcomeMessage, "welcomeMessage");
            welcomeMessage.ForeColor = Color.White;
            welcomeMessage.Name = "welcomeMessage";
            // 
            // roundPictureBox1
            // 
            resources.ApplyResources(roundPictureBox1, "roundPictureBox1");
            roundPictureBox1.Name = "roundPictureBox1";
            roundPictureBox1.TabStop = false;
            roundPictureBox1.Click += roundPictureBox1_Click;
            // 
            // Index
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            Controls.Add(roundPictureBox1);
            Controls.Add(welcomeMessage);
            Controls.Add(contactUs);
            Controls.Add(aboutUs);
            Controls.Add(footer);
            Controls.Add(storeButton);
            Controls.Add(servicesButton);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menu);
            DoubleBuffered = true;
            Name = "Index";
            Load += Index_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button footer;
        private Button storeButton;
        private Button servicesButton;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem MyReservations;
        private ToolStripMenuItem Management;
        private ToolStripMenuItem Home;
        private Label aboutUs;
        private Label contactUs;
        private Label welcomeMessage;
        private ToolStripMenuItem manageProducts;
        private ToolStripMenuItem manageServices;
        private Utilities.RoundPictureBox roundPictureBox1;
    }
}