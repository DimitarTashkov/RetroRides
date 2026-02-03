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
    public partial class ManageSouvenirs : Form
    {
        private readonly ISouvenirService _service;
        public ManageSouvenirs(ISouvenirService service)
        {
            InitializeComponent();
            _service = service;
        }
        private void ManageSouvenirs_Load(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(70, 130, 180);
            SetupGrid();
            LoadData();

            bool isAdmin = AuthorizationHelper.IsAuthorized();
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
        }

        private void SetupGrid()
        {
            dgvSouvenirs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSouvenirs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSouvenirs.ReadOnly = true;

            // Добавяме бутоните само ако ги няма
            if (!dgvSouvenirs.Columns.Contains("Edit"))
            {
                var editBtn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Actions"
                };
                dgvSouvenirs.Columns.Add(editBtn);
            }

            if (!dgvSouvenirs.Columns.Contains("Delete"))
            {
                var delBtn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Actions"
                };
                dgvSouvenirs.Columns.Add(delBtn);
            }

            // Презакачаме събитието за всеки случай
            dgvSouvenirs.CellContentClick -= DgvSouvenirs_CellContentClick;
            dgvSouvenirs.CellContentClick += DgvSouvenirs_CellContentClick;
        }

        private void LoadData()
        {
            dgvSouvenirs.DataSource = null;
            dgvSouvenirs.DataSource = _service.GetAllSouvenirs();

            // Скриваме ID и Пътя до снимката, за да е чисто
            if (dgvSouvenirs.Columns["Id"] != null) dgvSouvenirs.Columns["Id"].Visible = false;
            if (dgvSouvenirs.Columns["ImagePath"] != null) dgvSouvenirs.Columns["ImagePath"].Visible = false;

            // Форматиране на цената (ако искаш)
            if (dgvSouvenirs.Columns["Price"] != null) dgvSouvenirs.Columns["Price"].DefaultCellStyle.Format = "F2";
        }

        private void DgvSouvenirs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = (Souvenir)dgvSouvenirs.Rows[e.RowIndex].DataBoundItem;

            if (dgvSouvenirs.Columns[e.ColumnIndex].Name == "Edit")
            {
                // Отиваме към формата за редакция
                Program.SwitchMainForm(new AddEditSouvenir(_service, item));
            }
            else if (dgvSouvenirs.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show($"Are you sure you want to delete '{item.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _service.DeleteSouvenir(item.Id);
                    LoadData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Отиваме към формата за добавяне (null = нов запис)
            Program.SwitchMainForm(new AddEditSouvenir(_service, null));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var userService = ServiceLocator.GetService<IUserService>();
            Program.SwitchMainForm(new Index(userService));
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
