using Microsoft.EntityFrameworkCore;
using RetroRides.Data;
using RetroRides.Models;
using RetroRides.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services
{
    public class ReservationService : IReservationService
    {
        private readonly MuseumContext _context;

        public ReservationService(MuseumContext context)
        {
            _context = context;
        }

        public void CreateReservation(Guid userId, DateTime date, string notes)
        {
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                DateOfVisit = date,
                Status = "Pending",
                Notes = notes
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public List<Reservation> GetReservationsByUser(Guid userId)
        {
            return _context.Reservations
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.DateOfVisit)
                .ToList();
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations
                .Include("User") // Да видим кой е направил резервацията
                .OrderByDescending(r => r.DateOfVisit)
                .ToList();
        }

        public void UpdateStatus(Guid reservationId, string newStatus)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                reservation.Status = newStatus;
                _context.SaveChanges();
            }
        }
    }
}
