using RetroRides.Data.Models;
using RetroRides.Extensions;
using RetroRides.Models;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RetroRides.Forms
{
    public partial class Index : Form
    {
        // Дефинираме услугите (аналогично на Prisma)
        private readonly IUserService userService;
        private readonly ISouvenirService shopService;        // Аналог на ShopService
        private readonly IReservationService reservationService; // Аналог на SessionService
        private readonly IExhibitService exhibitService;      // Аналог на PhotoServiceManager

        private User activeUser;

        // Конструкторът приема само UserService, другите ги дърпаме с Locator-а
        public Index(IUserService userService)
        {
            this.userService = userService;

            // ServiceLocator pattern (както в Prisma)
            this.shopService = ServiceLocator.GetService<ISouvenirService>();
            this.reservationService = ServiceLocator.GetService<IReservationService>();
            this.exhibitService = ServiceLocator.GetService<IExhibitService>();

            // Взимаме текущия логнат потребител
            // Внимание: Увери се, че GetLoggedInUser() връща правилния User от сесията
            // Ако нямаш такъв метод в сървиса, ползвай AuthorizationHelper.CurrentUser
            activeUser = userService.GetLoggedInUserAsync();

            InitializeComponent();
            ApplyCustomStyles(); // Твоята стилизация
        }

        private void Index_Load(object sender, EventArgs e)
        {
            // Зареждане на аватар (ако имаш такова поле в User, иначе го коментирай)
            // roundPictureBox1.ImageLocation = activeUser.AvatarUrl; 

            // Проверка за админ права
            bool isAdmin = AuthorizationHelper.IsAuthorized(); // или .IsAuthorized(), зависи как е в RetroRides


            // Скриване/Показване на админ бутоните в менюто
            // Увери се, че в Designer-а тези ToolStripMenuItems се казват така:

             Users.Visible = isAdmin;
             Management.Visible = isAdmin;
        }

        // --- БЪРЗИ БУТОНИ ОТ ЕКРАНА ---

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            // Отиваме към профила
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }

        private void store_button_Click(object sender, EventArgs e)
        {
            // Отиваме към Магазина
            ShopForm shopForm = new ShopForm(shopService);
            Program.SwitchMainForm(shopForm);
        }

        private void servicesButton_Click(object sender, EventArgs e)
        {
            // В Prisma "Services" беше резервация, тук може да е Каталога или Резервацията
            // Нека води към Каталога с колите
            CatalogForm catalogForm = new CatalogForm(exhibitService);
            Program.SwitchMainForm(catalogForm);
        }

        // --- ГЛАВНО МЕНЮ (MenuStrip Logic) ---
        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            string formName = item.Name;
            Form form = new Index(userService); // Default

            switch (formName)
            {
                // Клиентски форми
                case "Store":
                    form = new ShopForm(shopService);
                    break;
                case "Catalog": // Беше Services
                    form = new CatalogForm(exhibitService);
                    break;
                case "Profile":
                    form = new Profile(userService);
                    break;
                case "MyReservations": // Поръчки/Резервации
                    // Тук трябва да направиш Orders формата да приема нужните сървиси
                    form = new Orders(reservationService, shopService, userService);
                    break;

                // Админ форми
                case "Users":
                    form = new Users(userService);
                    break;
                case "manageProducts": // Сувенири
                    form = new ManageSouvenirs(shopService);
                    break;
                case "manageExhibits": // Коли (беше manageServices)
                    form = new ManageExhibits(exhibitService);
                    break;

                // Начало
                case "Home":
                    form = new Index(userService);
                    break;
            }

            // Навигацията от Program.cs
            Program.SwitchMainForm(form);
        }

        // --- СТИЛИЗАЦИЯ (1:1 от Prisma) ---
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
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(100, 149, 237);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(70, 130, 180);
                }
                else if (ctrl is Label lbl)
                {
                    // Внимавай тук: ако имаш прозрачни лейбъли, това може да ги направи сини
                    // Може да сложиш проверка if (lbl.Tag == "header") ...

                    lbl.BackColor = Color.FromArgb(70, 130, 180);
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.ForeColor = Color.White;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.MouseEnter += (s, e) => lbl.BackColor = Color.FromArgb(100, 149, 237);
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