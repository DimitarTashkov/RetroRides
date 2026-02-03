using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroRides.Forms
{
    public partial class AboutUs : Form
    {
        private readonly IUserService userService;
        
        private User activeUser;
        public AboutUs()
        {
            this.userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();
            InitializeComponent();
        }
        private void LoadPortfolioContent()
        {
            // 1. Заглавие
            lblTitle.Text = "Vehicle museum RetroRides";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 2. Основно описание (Portfolio Bio)
            string text = "Welcome to RetroRides!\n\n" +
              "We are a museum dedicated to the golden era of automobiles. " +
              "Our mission is to preserve history on wheels.\n\n" +
              "Here you can explore legendary models like the Ford Mustang, " +
              "learn their history, and book your visit.\n\n" +
              "Thank you for being part of our journey!";

            if (lblDescription != null)
                lblDescription.Text = text;

            // Направи го да изглежда добре
            // (Увери се, че в Дизайнера Label-ът е достатъчно голям или AutoSize = true)

            // 3. Статистика (Доверие)
            if (lblStats != null)
            {
                lblStats.Text = "⭐ 3+ Years Experience   |   🚗 100+ Vehicles   |   ❤️ 200+ Happy Clients";
                lblStats.ForeColor = Color.DarkSlateGray;
                lblStats.TextAlign = ContentAlignment.MiddleCenter;
            }

        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            if (activeUser != null && roundPictureBox1 != null)
                 roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
            
            LoadPortfolioContent();
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
