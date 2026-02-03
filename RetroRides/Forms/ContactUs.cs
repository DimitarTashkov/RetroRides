using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using System;
using System.Windows.Forms;

namespace RetroRides.Forms
{
    public partial class ContactUs : Form
    {

        private User activeUser;
        private readonly IUserService userService;
        
        public ContactUs()
        {
            this.userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();

            InitializeComponent();
        }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            if (activeUser != null && roundPictureBox1 != null) // Avoid potential null ref if roundPictureBox1 not Init
                 roundPictureBox1.ImageLocation = activeUser.AvatarUrl;

            bool isAdmin = AuthorizationHelper.IsAuthorized();

            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
        }

        
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }

        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            string formName = item.Name;
            
            Form form = new Index(userService);

            switch (formName)
            {
                case "Store":
                    form = new Shop(ServiceLocator.GetService<ISouvenirService>());
                    break;
                case "Vehicles":
                    form = new Catalog();
                    break;
                case "MyReservations":
                    form = new Orders(ServiceLocator.GetService<IReservationService>(), ServiceLocator.GetService<ISouvenirService>(), userService);
                    break;
                case "Users":
                    form = new Users(userService);
                    break;
                case "manageProducts":
                    form = new ManageSouvenirs(ServiceLocator.GetService<ISouvenirService>());
                    break;
                case "manageVehicles":
                    form = new ManageExhibits(ServiceLocator.GetService<IExhibitService>());
                    break;
                case "Home":
                    form = new Index(userService);
                    break;
            }

            Program.SwitchMainForm(form);
        }
    }
}
