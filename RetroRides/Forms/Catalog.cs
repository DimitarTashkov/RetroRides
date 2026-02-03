using RetroRides.Extensions;
using RetroRides.Models;
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
    public partial class Catalog : Form
    {
        private readonly IExhibitService _service;
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;
        private User activeUser;

        public Catalog()
        {
            InitializeComponent();
            _userService = ServiceLocator.GetService<IUserService>();
            _reservationService = ServiceLocator.GetService<IReservationService>();
            _service = ServiceLocator.GetService<IExhibitService>();
            activeUser = _userService.GetLoggedInUserAsync();
        }
        private void CatalogForm_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;

            LoadCatalog();
        }

        private void LoadCatalog()
        {
            flowPanel.Controls.Clear();
            var exhibits = _service.GetAllExhibits(); // Трябва да имаш такъв метод в Service-а

            foreach (var item in exhibits)
            {
                // Пропускаме неактивните (ако имаш такава логика)
                // if (!item.IsActive) continue;

                // --- 1. КАРТА (Панел) ---
                Panel card = new Panel
                {
                    Size = new Size(230, 320),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    Margin = new Padding(15)
                };

                // --- 2. СНИМКА (RoundPictureBox) ---
                RoundPictureBox pb = new RoundPictureBox
                {
                    Size = new Size(210, 160),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.LightGray
                };

                // Зареждане на снимка (ако е URL или път)
                try
                {
                    if (!string.IsNullOrEmpty(item.ImagePath)) pb.Load(item.ImagePath);
                }
                catch { } // Ако гръмне снимката, остава сиво

                card.Controls.Add(pb);

                // --- 3. ЗАГЛАВИЕ ---
                Label lblTitle = new Label
                {
                    Text = $"{item.Make} {item.Model}",
                    Location = new Point(10, 180),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.DarkSlateBlue
                };
                card.Controls.Add(lblTitle);

                // --- 4. ГОДИНА ---
                Label lblYear = new Label
                {
                    Text = $"Year: {item.Year} | {item.Type}",
                    Location = new Point(10, 210),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };
                card.Controls.Add(lblYear);

                // --- 5. БУТОН ЗА РЕЗЕРВАЦИЯ ---
                Button btnBook = new Button
                {
                    Text = "Book Visit",
                    Location = new Point(20, 260),
                    Size = new Size(200, 40),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = item // Пазим ID-то тук!
                };
                btnBook.Click += BtnBook_Click;
                card.Controls.Add(btnBook);

                // Добавяме картата в FlowPanel-а
                flowPanel.Controls.Add(card);
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var car = (Exhibit)btn.Tag;

             Program.SwitchMainForm(new BookVisit(_reservationService,car));
        }

        // Вържи този метод към бутона Back от дизайнера
        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new Index(_userService));
        }

        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            string formName = item.Name;
            Form form = new Index(_userService);

            switch (formName)
            {
                case "Store":
                    form = new Shop(ServiceLocator.GetService<ISouvenirService>());
                    break;
                case "Vehicles":
                    form = new Catalog();
                    break;
                case "MyReservations":
                    form = new Orders(ServiceLocator.GetService<IReservationService>(), ServiceLocator.GetService<ISouvenirService>(), _userService);
                    break;
                case "Users":
                    form = new Users(_userService);
                    break;
                case "manageProducts":
                    form = new ManageSouvenirs(ServiceLocator.GetService<ISouvenirService>());
                    break;
                case "manageVehicles":
                    form = new ManageExhibits(ServiceLocator.GetService<IExhibitService>());
                    break;
                case "Home":
                    form = new Index(_userService);
                    break;
            }

            Program.SwitchMainForm(form);
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            if (activeUser != null)
            {
                Profile profileForm = new Profile(_userService, activeUser.Id);
                Program.SwitchMainForm(profileForm);
            }
        }
    }
}
