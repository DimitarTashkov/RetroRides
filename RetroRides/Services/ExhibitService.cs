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
    public class ExhibitService : IExhibitService
    {
        private readonly MuseumContext _context;

        public ExhibitService(MuseumContext context)
        {
            _context = context;
        }

        public List<Exhibit> GetAllExhibits()
        {
            // Връщаме само активните, освен ако не е за админ панел (тук връщаме всичко)
            return _context.Exhibits.ToList();
        }

        public List<Exhibit> GetExhibitsByType(string type)
        {
            return _context.Exhibits
                .Where(e => e.Type == type && e.IsActive)
                .ToList();
        }

        public void AddExhibit(Exhibit exhibit)
        {
            if (exhibit.Id == Guid.Empty)
            {
                exhibit.Id = Guid.NewGuid();
            }
            _context.Exhibits.Add(exhibit);
            _context.SaveChanges();
        }

        public void UpdateExhibit(Exhibit exhibit)
        {
            var existing = _context.Exhibits.Find(exhibit.Id);
            if (existing != null)
            {
                existing.Make = exhibit.Make;
                existing.Model = exhibit.Model;
                existing.Year = exhibit.Year;
                existing.Description = exhibit.Description;
                existing.ImagePath = exhibit.ImagePath;
                existing.Type = exhibit.Type;
                existing.IsActive = exhibit.IsActive;

                _context.SaveChanges();
            }
        }

        public void DeleteExhibit(Guid id)
        {
            var exhibit = _context.Exhibits.Find(id);
            if (exhibit != null)
            {
                // Soft delete (препоръчително) или Hard delete
                // exhibit.IsActive = false; 
                _context.Exhibits.Remove(exhibit); // Hard delete
                _context.SaveChanges();
            }
        }

        public Exhibit GetExhibitById(Guid id)
        {
            return _context.Exhibits.Find(id);
        }
    }
}
