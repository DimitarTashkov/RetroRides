namespace RetroRides.Forms
{
    partial class ContactUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactUs));
            label2 = new Label();
            roundPictureBox1 = new RetroRides.Utilities.RoundPictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Management = new ToolStripMenuItem();
            manageProducts = new ToolStripMenuItem();
            manageServices = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Name = "label2";
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
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.RetroRides_logo;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // ContactUs
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            Controls.Add(pictureBox1);
            Controls.Add(roundPictureBox1);
            Controls.Add(menu);
            Controls.Add(label2);
            Name = "ContactUs";
            Load += ContactUs_Load;
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Utilities.RoundPictureBox roundPictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Home;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem Management;
        private ToolStripMenuItem manageProducts;
        private ToolStripMenuItem manageServices;
        private ToolStripMenuItem MyReservations;
        private PictureBox pictureBox1;
    }
}