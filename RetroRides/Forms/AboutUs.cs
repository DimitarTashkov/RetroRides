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
            lblTitle.Text = "PHOTO STUDIO PRIZMA";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 2. Основно описание (Portfolio Bio)
            lblDescription.Text =
                "Welcome to Photo Studio Prizma – where moments become timeless memories.\n\n" +
                "Founded in 2026, we are a team of passionate photographers and videographers dedicated to visual storytelling. " +
                "We believe that every picture tells a story, and our mission is to capture yours with authenticity and style.\n\n" +
                "OUR SPECIALTIES:\n" +
                "• Professional Headshots & Portraits\n" +
                "• Wedding & Event Photography\n" +
                "• Commercial & Product Photography\n" +
                "• Fine Art Prints";

            // Направи го да изглежда добре
            // (Увери се, че в Дизайнера Label-ът е достатъчно голям или AutoSize = true)

            // 3. Статистика (Доверие)
            if (lblStats != null)
            {
                lblStats.Text = "⭐ 5+ Years Experience   |   📸 1200+ Photo Sessions   |   ❤️ 500+ Happy Clients";
                lblStats.ForeColor = Color.DarkSlateGray;
                lblStats.TextAlign = ContentAlignment.MiddleCenter;
            }

        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }
            LoadPortfolioContent();
        }
        
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
    }
}
