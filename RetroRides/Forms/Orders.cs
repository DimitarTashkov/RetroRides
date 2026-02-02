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
            // Настройки за таблицата с Резервации
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.ReadOnly = true;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Настройки за таблицата с Поръчки
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {

            bool isAdmin = AuthorizationHelper.IsAuthorized();

            // 1. ЗАРЕЖДАНЕ НА РЕЗЕРВАЦИИ
            var reservations = isAdmin
                ? _reservationService.GetAllReservations() // Админът вижда всичко
                : _reservationService.GetReservationsByUser(activeUser.Id); // Клиентът - само своите

            // Мапваме към анонимен обект за по-чист вид в таблицата
            dgvReservations.DataSource = reservations.Select(r => new
            {
                Date = r.DateOfVisit,
                Notes = r.Notes,
                User = isAdmin ? r.User.Username : "Me" // Показваме user само ако е админ
            }).ToList();


            // 2. ЗАРЕЖДАНЕ НА ПОРЪЧКИ (СУВЕНИРИ)
            var orders = isAdmin
                ? _souvenirService.GetAllOrders()
                : _souvenirService.GetOrdersByUserId(activeUser.Id);

            // Тук е малко по-сложно, защото една поръчка може да има много продукти.
            // За простота ще покажем основното инфо.
            dgvOrders.DataSource = orders.Select(o => new
            {
                OrderDate = o.OrderDate,
                Total = $"{o.TotalAmount:F2} BGN",
                ItemsCount = o.OrderItems.Count,
                Details = string.Join(", ", o.OrderItems.Select(i => $"{i.Souvenir?.Name} (x{i.Quantity})")),
                User = isAdmin ? o.User.Username : "Me"
            }).ToList();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            SetupGrids();
            LoadData();
        }
    }
}
