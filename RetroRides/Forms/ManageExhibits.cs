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
    public partial class ManageExhibits : Form
    {
        private readonly IExhibitService _service;
        public ManageExhibits(IExhibitService service)
        {
            InitializeComponent();
            this._service = service;
        }

        private void ManageExhibits_Load(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(70, 130, 180);
            SetupGrid();
            LoadData();
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
            }else if (dgvExhibits.Columns[e.ColumnIndex].Name == "Edit")
            {
                Program.SwitchMainForm(new AddEditExhibit(_service, exhibit));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   
            Program.SwitchMainForm(new AddEditExhibit(_service, null));
        }
    }
}
