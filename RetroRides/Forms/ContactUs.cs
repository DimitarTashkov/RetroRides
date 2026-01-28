using RetroRides.Extensions;
using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
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
    public partial class ContactUs : Form
    {

        private User activeUser;
        private readonly IUserService userService;
        private readonly IShopService shopService = ServiceLocator.GetService<IShopService>();
        private readonly ISessionService sessionService = ServiceLocator.GetService<ISessionService>();
        private readonly IPhotoServiceManager serviceManager = ServiceLocator.GetService<IPhotoServiceManager>();
        public ContactUs()
        {
            this.userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();

            InitializeComponent();
        }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }
        }

        
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
    }
}
