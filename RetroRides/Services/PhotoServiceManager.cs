using Microsoft.EntityFrameworkCore;
using RetroRides.Data;
using RetroRides.Data.Models;
using RetroRides.Data.Models;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using RetroRides.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetroRides.Services
{
    public class PhotoServiceManager : BaseService, IPhotoServiceManager
    {
        private readonly PrismContext Context;

        public PhotoServiceManager(PrismContext context)
        {
            this.Context = context;
        }

        public List<PhotoService> GetAllServices()
        {
            return this.Context.PhotoServices.ToList();
        }

        public PhotoService GetServiceById(Guid id)
        {
            return this.Context.PhotoServices.FirstOrDefault(s => s.Id == id);
        }
        public void AddService(PhotoService service)
        {
            Context.PhotoServices.Add(service);
            Context.SaveChanges();
        }

        public void UpdateService(PhotoService service)
        {
            var existing = Context.PhotoServices.Find(service.Id);
            if (existing != null)
            {
                existing.Name = service.Name;
                existing.Price = service.Price;
                existing.DurationMinutes = service.DurationMinutes; // <-- Разликата с продуктите
                existing.Description = service.Description;
                existing.ImageUrl = service.ImageUrl;

                Context.SaveChanges();
            }
        }

        public void CreateService(string name, string description, decimal price, int durationMinutes, string imageUrl)
        {
            var service = new PhotoService
            {
                Id = Guid.NewGuid(), // Генерираме ново ID
                Name = name,
                Description = description,
                Price = price,
                DurationMinutes = durationMinutes,
                ImageUrl = imageUrl
            };

            this.Context.PhotoServices.Add(service);
            this.Context.SaveChanges();
        }

        public void EditService(Guid id, string name, string description, decimal price, int durationMinutes, string imageUrl)
        {
            var service = this.GetServiceById(id);
            if (service != null)
            {
                service.Name = name;
                service.Description = description;
                service.Price = price;
                service.DurationMinutes = durationMinutes;

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    service.ImageUrl = imageUrl;
                }

                this.Context.SaveChanges();
            }
        }

        public void DeleteService(Guid id)
        {
            var service = this.GetServiceById(id);
            if (service != null)
            {
                this.Context.PhotoServices.Remove(service);
                this.Context.SaveChanges();
            }
        }
    }
}