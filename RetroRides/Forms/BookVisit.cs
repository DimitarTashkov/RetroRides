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
    public partial class BookVisit : Form
    {
        private readonly IReservationService _reservationService;
        private readonly Exhibit _selectedExhibit; // Колата, за която е резервацията
        private readonly IExhibitService exhibitService;
        private readonly IUserService userService = ServiceLocator.GetService<IUserService>();
        private User? currrentUser;

        public BookVisit(IReservationService reservationService, Exhibit exhibit)
        {
            InitializeComponent();
            _reservationService = reservationService;
            _selectedExhibit = exhibit;
            exhibitService = ServiceLocator.GetService<IExhibitService>();
            currrentUser = userService.GetLoggedInUserAsync();
        }

        private void BookVisit_Load(object sender, EventArgs e)
        {
            SetupUI();
            pictureBox1.ImageLocation = _selectedExhibit.ImagePath;
            
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
        }
        private void SetupUI()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Book Museum Visit";

            // Настройка на полето за дата
            dtpDate.MinDate = DateTime.Now; // Да не може да избира минало време
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";

            // Попълване на инфо за колата
            if (_selectedExhibit != null)
            {
                lblCarInfo.Text = $"Visiting: {_selectedExhibit.Make} {_selectedExhibit.Model} ({_selectedExhibit.Year})";
                lblCarInfo.ForeColor = Color.DarkSlateBlue;
            }
            else
            {
                lblCarInfo.Text = "General Visit (No specific vehicle selected)";
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            // 2. Събиране на данните
            DateTime date = dtpDate.Value;
            string notes = txtNotes.Text;

            // Добавяме инфото за колата в бележките автоматично
            if (_selectedExhibit != null)
            {
                notes = $"[Vehicle Interest: {_selectedExhibit.Make} {_selectedExhibit.Model}] " + notes;
            }

            // 3. Създаване на резервация
            try
            {
                _reservationService.CreateReservation(currrentUser.Id, date, notes);

                MessageBox.Show("Reservation confirmed! You can see it in 'My Reservations'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Връщаме към каталога или към моите резервации
                Program.SwitchMainForm(new Catalog());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new Catalog());
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
