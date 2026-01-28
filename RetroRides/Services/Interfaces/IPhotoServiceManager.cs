using RetroRides.Data.Models;
using RetroRides.Data.Models;
using System;
using System.Collections.Generic;

namespace RetroRides.Services.Interfaces
{
    public interface IPhotoServiceManager
    {
        List<PhotoService> GetAllServices();
        PhotoService GetServiceById(Guid id); // int -> Guid
        void CreateService(string name, string description, decimal price, int durationMinutes, string imageUrl);
        void EditService(Guid id, string name, string description, decimal price, int durationMinutes, string imageUrl); // int -> Guid
        void DeleteService(Guid id);
        void AddService(PhotoService service);
        void UpdateService(PhotoService service);
    }
}