using RetroRides.Models;
using RetroRides.Services.Interfaces;
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
    public partial class Shop : Form
    {
        private readonly ISouvenirService _service;
        public Shop(ISouvenirService service)
        {
            InitializeComponent();
            this._service = service;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            LoadShop();
        }
        private void LoadShop()
        {
            if (flowLayoutPanel1 == null) return;
            flowLayoutPanel1.Controls.Clear();

            var items = _service.GetAllSouvenirs();

            foreach (var item in items)
            {
                if (item.StockQuantity <= 0) continue;

                Panel card = new Panel
                {
                    Size = new Size(200, 260),
                    BackColor = Color.WhiteSmoke,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblName = new Label
                {
                    Text = item.Name,
                    Location = new Point(10, 10),
                    Width = 180,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                Label lblPrice = new Label
                {
                    Text = $"{item.Price:F2} BGN",
                    Location = new Point(10, 40),
                    ForeColor = Color.Green,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };

                Button btnBuy = new Button
                {
                    Text = "Buy Now",
                    Location = new Point(10, 200),
                    Size = new Size(178, 40),
                    BackColor = Color.Orange,
                    FlatStyle = FlatStyle.Flat,
                    Tag = item
                };
                btnBuy.Click += BtnBuy_Click;

                card.Controls.Add(lblName);
                card.Controls.Add(lblPrice);
                card.Controls.Add(btnBuy);

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            var item = (Souvenir)((Button)sender).Tag;
            MessageBox.Show($"Purchase logic for: {item.Name}");
        }
    }
}
