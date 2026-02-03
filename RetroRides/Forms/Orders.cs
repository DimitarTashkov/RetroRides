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
    public partial class Orders : Form
    {
        private readonly IReservationService _reservationService;
        private readonly ISouvenirService _souvenirService;
        private readonly IUserService _userService;
        private User? activeUser;
        public Orders(IReservationService resService, ISouvenirService soupService, IUserService userService)
        {
            InitializeComponent();
            _reservationService = resService;
            _souvenirService = soupService;
            _userService = userService;
            activeUser = _userService.GetLoggedInUserAsync();
        }
        private void SetupGrids()
        {
            // === 1. Таблица РЕЗЕРВАЦИИ ===
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.ReadOnly = true;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Добавяме бутон за триене, ако го няма
            if (!dgvReservations.Columns.Contains("Cancel"))
            {
                var btnCancel = new DataGridViewButtonColumn
                {
                    Name = "Cancel",
                    HeaderText = "Actions",
                    Text = "Cancel Reservation",
                    UseColumnTextForButtonValue = true
                };
                dgvReservations.Columns.Add(btnCancel);
            }

            // Закачаме събитието за клик
            dgvReservations.CellContentClick -= DgvReservations_CellContentClick;
            dgvReservations.CellContentClick += DgvReservations_CellContentClick;


            // === 2. Таблица ПОРЪЧКИ ===
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Добавяме бутон за триене на поръчка (само за админ или ако позволиш на user)
            if (!dgvOrders.Columns.Contains("Delete"))
            {
                var btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Actions",
                    Text = "Delete Order",
                    UseColumnTextForButtonValue = true
                };
                dgvOrders.Columns.Add(btnDelete);
            }
            if (!dgvOrders.Columns.Contains("Invoice"))
            {
                var btnInvoice = new DataGridViewButtonColumn
                {
                    Name = "Invoice",
                    HeaderText = "Document",
                    Text = "View Invoice",
                    UseColumnTextForButtonValue = true
                };
                dgvOrders.Columns.Add(btnInvoice);
            }

            // Закачаме събитието за клик
            dgvOrders.CellContentClick -= DgvOrders_CellContentClick;
            dgvOrders.CellContentClick += DgvOrders_CellContentClick;
        }

        private void LoadData()
        {
            if (activeUser == null) return;

            bool isAdmin = AuthorizationHelper.IsAuthorized();

            // --- ЗАРЕЖДАНЕ НА РЕЗЕРВАЦИИ ---
            var reservations = isAdmin
                ? _reservationService.GetAllReservations()
                : _reservationService.GetReservationsByUser(activeUser.Id);

            // ВАЖНО: Включваме Id в селекцията, за да можем да трием после!
            dgvReservations.DataSource = reservations.Select(r => new
            {
                Id = r.Id, // <--- ТОВА Е ВАЖНОТО
                Date = r.DateOfVisit,
                Notes = r.Notes,
                User = isAdmin ? r.User.Username : "Me"
            }).ToList();

            // Скриваме колоната ID, за да е красиво
            if (dgvReservations.Columns["Id"] != null) dgvReservations.Columns["Id"].Visible = false;


            // --- ЗАРЕЖДАНЕ НА ПОРЪЧКИ ---
            var orders = isAdmin
                ? _souvenirService.GetAllOrders()
                : _souvenirService.GetOrdersByUserId(activeUser.Id);

            dgvOrders.DataSource = orders.Select(o => new
            {
                Id = o.Id, // <--- ТОВА Е ВАЖНОТО
                OrderDate = o.OrderDate,
                Total = $"{o.TotalAmount:F2} BGN",
                ItemsCount = o.OrderItems.Count,
                Details = string.Join(", ", o.OrderItems.Select(i => $"{i.Souvenir?.Name} (x{i.Quantity})")),
                User = isAdmin ? o.User.Username : "Me"
            }).ToList();

            // Скриваме колоната ID
            if (dgvOrders.Columns["Id"] != null) dgvOrders.Columns["Id"].Visible = false;
        }

        // === ЛОГИКА ЗА ТРИЕНЕ НА РЕЗЕРВАЦИИ ===
        private void DgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверка дали е натиснат бутона "Cancel" и дали реда е валиден
            if (e.RowIndex >= 0 && dgvReservations.Columns[e.ColumnIndex].Name == "Cancel")
            {
                if (MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        // Взимаме ID-то от скритата колона
                        Guid id = (Guid)dgvReservations.Rows[e.RowIndex].Cells["Id"].Value;

                        // Трябва да имаш DeleteReservation в IReservationService!
                        _reservationService.DeleteReservation(id);

                        LoadData(); // Презареждаме таблицата
                        MessageBox.Show("Reservation cancelled.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // === ЛОГИКА ЗА ТРИЕНЕ НА ПОРЪЧКИ ===
        private void DgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        Guid id = (Guid)dgvOrders.Rows[e.RowIndex].Cells["Id"].Value;

                        // Трябва да имаш DeleteOrder в ISouvenirService!
                        _souvenirService.DeleteOrder(id);

                        LoadData();
                        MessageBox.Show("Order deleted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            if (e.RowIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "Invoice")
            {
                // Взимаме ID-то
                Guid orderId = (Guid)dgvOrders.Rows[e.RowIndex].Cells["Id"].Value;

                // Намираме цялата поръчка от сървиса (или от локалния списък ако го пазиш)
                // Тъй като dgvDataSource е анонимен обект, трябва да я намерим:
                var order = _souvenirService.GetAllOrders().FirstOrDefault(o => o.Id == orderId); // Това е бавно, по-добре си пази списъка в променлива

                if (order != null)
                {
                    string invoiceText = InvoiceHelper.GenerateOrderInvoice(order);
                    MessageBox.Show(invoiceText, "Order Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            SetupGrids();
            LoadData();

            bool isAdmin = AuthorizationHelper.IsAuthorized();
            Users.Visible = isAdmin;
            Management.Visible = isAdmin;
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Index homeForm = new Index(_userService);
            Program.SwitchMainForm(homeForm);
        }
    }
}
