using RetroRides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services.Interfaces
{
    public interface IReservationService // Бившето ISessionService
    {
        void CreateReservation(Guid userId, DateTime date, string notes);
        List<Reservation> GetReservationsByUser(Guid userId);
        List<Reservation> GetAllReservations(); // За админа
        void UpdateStatus(Guid reservationId, string newStatus);
    }
}
