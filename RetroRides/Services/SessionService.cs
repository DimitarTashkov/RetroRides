using Microsoft.EntityFrameworkCore;
using RetroRides.Data;
using RetroRides.Data.Models;
using RetroRides.Services.Interfaces;
using RetroRides.Data.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetroRides.Services
{
    public class SessionService : BaseService, ISessionService
    {
        private readonly TimeSpan WorkDayStart = new TimeSpan(9, 0, 0);
        private readonly TimeSpan WorkDayEnd = new TimeSpan(18, 0, 0);

        private readonly PrismContext Context;

        public SessionService(PrismContext context)
        {
            this.Context = context;
        }

        public bool BookSession(Guid userId, Guid serviceId, DateTime date, TimeSpan time, string notes)
        {
            var service = this.Context.PhotoServices.Find(serviceId);
            if (service == null) return false;

            if (!IsSlotFree(date, time, service.DurationMinutes))
            {
                return false;
            }

            var session = new PhotoSession
            {
                Id = Guid.NewGuid(), // Генерираме ново ID
                UserId = userId,
                PhotoServiceId = serviceId,
                SessionDate = date.Date,
                StartTime = time,
                Notes = notes,
                IsConfirmed = false
            };

            this.Context.PhotoSessions.Add(session);
            this.Context.SaveChanges();
            return true;
        }

        public List<TimeSpan> GetAvailableSlots(DateTime date, int serviceDurationMinutes)
        {
            var availableSlots = new List<TimeSpan>();
            TimeSpan currentSlot = WorkDayStart;

            while (currentSlot.Add(TimeSpan.FromMinutes(serviceDurationMinutes)) <= WorkDayEnd)
            {
                if (IsSlotFree(date, currentSlot, serviceDurationMinutes))
                {
                    availableSlots.Add(currentSlot);
                }
                currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
            }

            return availableSlots;
        }

        private bool IsSlotFree(DateTime date, TimeSpan startTime, int durationMinutes)
        {
            TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(durationMinutes));

            var sessionsThatDay = this.Context.PhotoSessions
                .Where(s => s.SessionDate.Date == date.Date)
                .Include(s => s.PhotoService)
                .ToList();

            foreach (var session in sessionsThatDay)
            {
                TimeSpan existingStart = session.StartTime;
                TimeSpan existingEnd = session.StartTime.Add(TimeSpan.FromMinutes(session.PhotoService.DurationMinutes));

                bool overlap = (startTime < existingEnd) && (existingStart < endTime);

                if (overlap)
                {
                    return false;
                }
            }

            return true;
        }

        public List<PhotoSession> GetUserSessions(Guid userId)
        {
            return this.Context.PhotoSessions
                .Include(s => s.PhotoService)
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToList();
        }

        public List<PhotoSession> GetAllUpcomingSessions()
        {
            return this.Context.PhotoSessions
                .Include(s => s.User)
                .Include(s => s.PhotoService)
                .Where(s => s.SessionDate >= DateTime.Today)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToList();
        }

        public void CancelSession(Guid sessionId)
        {
            var session = this.Context.PhotoSessions.Find(sessionId);
            if (session != null)
            {
                this.Context.PhotoSessions.Remove(session);
                this.Context.SaveChanges();
            }
        }
        public void ConfirmSession(Guid sessionId)
        {
            var session = Context.PhotoSessions.Find(sessionId);
            if (session != null)
            {
                session.IsConfirmed = true;
                Context.SaveChanges();
            }
        }

        public void DeclineSession(Guid sessionId)
        {
            var session = Context.PhotoSessions.Find(sessionId);
            if (session != null)
            {
                // Вариант 1: Изтриваме я напълно
                Context.PhotoSessions.Remove(session);
                Context.SaveChanges();
            }
        }
    }
}