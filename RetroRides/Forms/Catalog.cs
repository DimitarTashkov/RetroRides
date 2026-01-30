using RetroRides.Extensions;
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
        public Catalog()
        {
            InitializeComponent();
            _userService = ServiceLocator.GetService<IUserService>();
        }
        private void CatalogForm_Load(object sender, EventArgs e)
        {
            LoadCatalog();
            this.Load += CatalogForm_Load;
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
                    Size = new Size(240, 320),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    Margin = new Padding(15)
                };

                // --- 2. СНИМКА (RoundPictureBox) ---
                RoundPictureBox pb = new RoundPictureBox
                {
                    Size = new Size(220, 160),
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
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
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
                    Tag = item.Id // Пазим ID-то тук!
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
            Guid carId = (Guid)btn.Tag;

            // Тук ще пренасочваме към формата за резервация по-нататък
            MessageBox.Show($"Redirecting to booking for car ID: {carId}");

            // Program.SwitchMainForm(new BookVisitForm(carId));
        }

        // Вържи този метод към бутона Back от дизайнера
        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new Index(_userService));
        }
    }
}
