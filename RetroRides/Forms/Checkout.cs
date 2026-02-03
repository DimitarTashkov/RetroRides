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
    public partial class Checkout : Form
    {
        private readonly ISouvenirService _service;
        private readonly Souvenir _item;
        private readonly User _user;
        private readonly IUserService userService;
        private readonly IReservationService reservationService = ServiceLocator.GetService<IReservationService>();
        private readonly IExhibitService exhibitService = ServiceLocator.GetService<IExhibitService>();
        private User activeUser;
        public Checkout(ISouvenirService service, Souvenir item, User user)
        {
            InitializeComponent();
            _service = service;
            _item = item;
            _user = user;
            this.userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();
            SetupUI();
        }
        private void SetupUI()
        {

            this.Text = "Checkout";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Показваме какво купува
            itemsBox.Items.Add(itemsBox.Items.Count + 1 + $". {_item.Name} - {_item.Price:F2} BGN");

            // Ако искаш, може да пре-попълниш полетата, ако ги имаш в User профила
            // txtPhone.Text = ...
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Валидация
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter both Delivery Address and Phone Number.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Покупка
                _service.PurchaseItem(_user.Id, _item.Id, 1, txtAddress.Text, txtPhone.Text);

                // 3. Създаваме временен обект Order, за да покажем фактура веднага (опционално)
                // Или просто казваме Успех.

                MessageBox.Show("Order placed successfully! Please save your invoice.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Тук може да генерираме фактурата веднага, но по-добре потребителят да си я види в Orders

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;

            bool isAdmin = AuthorizationHelper.IsAuthorized();

            Users.Visible = isAdmin;
            Management.Visible = isAdmin;

        }
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            // Отиваме към профила
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
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
                    form = new Shop(_service);
                    break;
                case "Vehicles": // Беше Services
                    form = new Catalog();
                    break;
                case "MyReservations": // Поръчки/Резервации
                    // Тук трябва да направиш Orders формата да приема нужните сървиси
                    form = new Orders(reservationService, _service, userService);
                    break;

                // Админ форми
                case "Users":
                    form = new Users(userService);
                    break;
                case "manageProducts": // Сувенири
                    form = new ManageSouvenirs(_service);
                    break;
                case "manageVehicles": // Коли (беше manageServices)
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
    }
}
