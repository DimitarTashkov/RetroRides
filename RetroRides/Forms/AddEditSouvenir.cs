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
using System.Xml.Linq;

namespace RetroRides.Forms
{
    public partial class AddEditSouvenir : Form
    {
        private readonly ISouvenirService _service;
        private Souvenir _souvenir;
        private string _selectedImagePath = null;
        public AddEditSouvenir(ISouvenirService service, Souvenir souvenir)
        {
            InitializeComponent();
            InitializeComponent();
            _service = service;
            _souvenir = souvenir; // Ако е null, ще го инициализираме долу

            SetupUI();
            
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
        }
        private void SetupUI()
        {
            this.StartPosition = FormStartPosition.CenterScreen;


            if (_souvenir != null)
            {
                this.Text = "Edit Product";
                txtName.Text = _souvenir.Name;
                txtPrice.Text = _souvenir.Price.ToString("F2"); // Трябва да е десетична точка, не запетая в кода
                txtStock.Text = _souvenir.StockQuantity.ToString();

                if (!string.IsNullOrEmpty(_souvenir.ImagePath) && File.Exists(_souvenir.ImagePath))
                {
                    try
                    {
                        pbImage.Image = Image.FromFile(_souvenir.ImagePath);
                        _selectedImagePath = _souvenir.ImagePath;
                    }
                    catch { pbImage.BackColor = Color.Gray; }
                }
            }
            else
            {
                this.Text = "Add New Product";
                _souvenir = new Souvenir(); // Нов обект
            }
        }

        private void PbImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Product Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbImage.Image = Image.FromFile(ofd.FileName);
                    _selectedImagePath = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валидация
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required!"); return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price format!"); return;
            }
            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Invalid Stock format!"); return;
            }

            // 2. Обработка на снимката (Копиране в PhotosStorage)
            string finalImagePath = _selectedImagePath;
            if (_selectedImagePath != null && !_selectedImagePath.Contains("PhotosStorage"))
            {
                string storageFolder = Path.Combine(Application.StartupPath, "PhotosStorage");
                if (!Directory.Exists(storageFolder)) Directory.CreateDirectory(storageFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_selectedImagePath);
                string destPath = Path.Combine(storageFolder, fileName);

                try
                {
                    File.Copy(_selectedImagePath, destPath, true);
                    finalImagePath = destPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message);
                    return;
                }
            }

            // 3. Пълним обекта
            _souvenir.Name = txtName.Text;
            _souvenir.Price = price;
            _souvenir.StockQuantity = stock;
            _souvenir.ImagePath = finalImagePath;

            // 4. Запис в базата
            try
            {
                if (_souvenir.Id == Guid.Empty)
                    _service.AddSouvenir(_souvenir);
                else
                    _service.UpdateSouvenir(_souvenir);

                MessageBox.Show("Product saved successfully!");
                Program.SwitchMainForm(new ManageSouvenirs(_service));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new ManageSouvenirs(_service));

        }

        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            string formName = item.Name;
            var userService = ServiceLocator.GetService<IUserService>();
            Form form = new Index(userService);

            switch (formName)
            {
                case "Store":
                    form = new Shop(_service);
                    break;
                case "Vehicles":
                    form = new Catalog();
                    break;
                case "MyReservations":
                    form = new Orders(ServiceLocator.GetService<IReservationService>(), _service, userService);
                    break;
                case "Users":
                    form = new Users(userService);
                    break;
                case "manageProducts":
                    form = new ManageSouvenirs(_service);
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

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            var userService = ServiceLocator.GetService<IUserService>();
            var activeUser = userService.GetLoggedInUserAsync();
            if (activeUser != null)
            {
                Profile profileForm = new Profile(userService, activeUser.Id);
                Program.SwitchMainForm(profileForm);
            }
        }

    }
}
