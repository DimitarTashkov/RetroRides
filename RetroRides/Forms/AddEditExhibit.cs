using RetroRides.Models;
using RetroRides.Services.Interfaces;
using RetroRides.Utilities;
using RetroRides.Extensions;
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
    public partial class AddEditExhibit : Form
    {
        private readonly IExhibitService _service;
        private Exhibit _exhibit; // Текущият обект (ако е null = нов)
        private string _selectedImagePath = null; // Пазим пътя до новата снимка
        private readonly IUserService userService;
        private User activeUser;

        public AddEditExhibit(IExhibitService exhibitService, Exhibit? exhibit)
        {
            InitializeComponent();
            _service = exhibitService;
            _exhibit = exhibit; 
            userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();
        }

        private void AddEditExhibit_Load(object sender, EventArgs e)
        {
            SetupUI();
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
        }
        private void SetupUI()
        {
            this.StartPosition = FormStartPosition.CenterScreen;


            // Проверка дали редактираме или създаваме
            if (_exhibit != null)
            {
                this.Text = "Edit Vehicle";
                FillForm();
            }
            else
            {
                this.Text = "Add New Vehicle";
                _exhibit = new Exhibit(); // Инициализираме празен
            }
        }

        private void FillForm()
        {
            txtMake.Text = _exhibit.Make;
            txtModel.Text = _exhibit.Model;
            txtDescription.Text = _exhibit.Description;

            if (!string.IsNullOrEmpty(_exhibit.Type))
                cmbType.SelectedItem = _exhibit.Type;

            if (_exhibit.Year > 0)
                numYear.Value = _exhibit.Year;

            // Зареждане на снимка
            if (!string.IsNullOrEmpty(_exhibit.ImagePath) && File.Exists(_exhibit.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_exhibit.ImagePath);
                    _selectedImagePath = _exhibit.ImagePath;
                }
                catch { pbImage.BackColor = Color.Gray; }
            }
        }

        // === ИЗБОР НА СНИМКА (Логика от Prisma ManageProducts) ===
        private void PbImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Vehicle Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Показваме веднага
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    // Пазим пътя за по-късно (при Save)
                    _selectedImagePath = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валидация
            if (string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Make and Model are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Please select a Type (Car/Motorcycle)!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Обработка на снимката (Копиране в PhotosStorage - Логика от Prisma)
            string finalImagePath = _selectedImagePath;

            if (_selectedImagePath != null && !_selectedImagePath.Contains("PhotosStorage"))
            {
                // Създаваме папка, ако я няма
                string storageFolder = Path.Combine(Application.StartupPath, "PhotosStorage");
                if (!Directory.Exists(storageFolder)) Directory.CreateDirectory(storageFolder);

                // Генерираме уникално име
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_selectedImagePath);
                string destPath = Path.Combine(storageFolder, fileName);

                // Копираме
                try
                {
                    File.Copy(_selectedImagePath, destPath, true);
                    finalImagePath = destPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying image: " + ex.Message);
                    return;
                }
            }

            // 3. Запис в обекта
            _exhibit.Make = txtMake.Text;
            _exhibit.Model = txtModel.Text;
            _exhibit.Type = cmbType.SelectedItem.ToString();
            _exhibit.Year = (int)numYear.Value;
            _exhibit.Description = txtDescription.Text;
            _exhibit.ImagePath = finalImagePath;
            _exhibit.IsActive = true;

            // 4. Извикване на Сървиса
            try
            {
                if (_exhibit.Id == Guid.Empty)
                {
                    _service.AddExhibit(_exhibit);
                }
                else
                {
                    _service.UpdateExhibit(_exhibit);
                }

                MessageBox.Show("Vehicle saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.SwitchMainForm(new ManageExhibits(_service));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new ManageExhibits(_service));
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
                    form = new ManageExhibits(_service);
                    break;
                case "Home":
                    form = new Index(userService);
                    break;
            }

            Program.SwitchMainForm(form);
        }
    }
}
