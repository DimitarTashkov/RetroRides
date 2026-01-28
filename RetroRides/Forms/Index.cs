using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using RetroRides;
using System.Drawing;
using System.Windows.Forms;

namespace RetroRides.Forms
{
    public partial class Index : Form
    {
        private readonly IUserService userService;
        private readonly IShopService shopService;
        private readonly ISessionService sessionService;
        private readonly IPhotoServiceManager serviceManager;

        private User activeUser;

        public Index(IUserService userService)
        {
            this.userService = userService;
            this.shopService = ServiceLocator.GetService<IShopService>();
            this.sessionService = ServiceLocator.GetService<ISessionService>();
            this.serviceManager = ServiceLocator.GetService<IPhotoServiceManager>();
            activeUser = userService.GetLoggedInUserAsync();


            InitializeComponent();
            ApplyCustomStyles(); // Приложи стилизация
        }

        private void Index_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            welcomeMessage.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            welcomeMessage.Cursor = Cursors.Default;



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
     

        // === Променен дизайн ===
        private void ApplyCustomStyles()
        {
            foreach (Control ctrl in this.Controls)
            {
                this.BackColor = Color.FromArgb(230, 240, 250); // Лек син фон

                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(70, 130, 180); // Стилен син
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(100, 149, 237); // По-светло синьо
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(70, 130, 180);
                }
                else if (ctrl is Label lbl)
                {
                    lbl.BackColor = Color.FromArgb(70, 130, 180); // Стилен син
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.ForeColor = Color.White;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.MouseEnter += (s, e) => lbl.BackColor = Color.FromArgb(100, 149, 237); // По-светло синьо
                    lbl.MouseLeave += (s, e) => lbl.BackColor = Color.FromArgb(70, 130, 180);
                }
            }


        }

        private void aboutUs_Click(object sender, EventArgs e)
        {
            AboutUs aboutUsForm = new AboutUs();
            Program.SwitchMainForm(aboutUsForm);
        }

        private void contactUs_Click(object sender, EventArgs e)
        {
            ContactUs contactUsForm = new ContactUs();
            Program.SwitchMainForm(contactUsForm);
        }
    }
}
