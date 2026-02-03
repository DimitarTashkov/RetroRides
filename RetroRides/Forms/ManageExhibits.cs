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
    public partial class ManageExhibits : Form
    {
        private readonly IExhibitService _service;
        private readonly IUserService _userService;
        public ManageExhibits(IExhibitService service)
        {
            InitializeComponent();
            this._service = service;
            this._userService = ServiceLocator.GetService<IUserService>();
        }

        private void ManageExhibits_Load(object sender, EventArgs e)
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
            dgvExhibits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExhibits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (!dgvExhibits.Columns.Contains("Edit"))
            {
                var editBtn = new DataGridViewButtonColumn { Name = "Edit", Text = "Edit", UseColumnTextForButtonValue = true };
                dgvExhibits.Columns.Add(editBtn);
            }
            if (!dgvExhibits.Columns.Contains("Delete"))
            {
                var delBtn = new DataGridViewButtonColumn { Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true };
                dgvExhibits.Columns.Add(delBtn);
            }

            dgvExhibits.CellContentClick -= DgvExhibits_CellContentClick;
            dgvExhibits.CellContentClick += DgvExhibits_CellContentClick;
        }

        private void LoadData()
        {
            dgvExhibits.DataSource = null;
            dgvExhibits.DataSource = _service.GetAllExhibits();
            if (dgvExhibits.Columns["Id"] != null) dgvExhibits.Columns["Id"].Visible = false;
        }

        private void DgvExhibits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var exhibit = (Exhibit)dgvExhibits.Rows[e.RowIndex].DataBoundItem;

            if (dgvExhibits.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _service.DeleteExhibit(exhibit.Id);
                    LoadData();
                }
            }
            else if (dgvExhibits.Columns[e.ColumnIndex].Name == "Edit")
            {
                Program.SwitchMainForm(new AddEditExhibit(_service, exhibit));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new AddEditExhibit(_service, null));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new Index(_userService));
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
