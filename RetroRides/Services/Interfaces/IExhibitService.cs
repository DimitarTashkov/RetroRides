using RetroRides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services.Interfaces
{
    public interface IExhibitService
    {
        List<Exhibit> GetAllExhibits();
        List<Exhibit> GetExhibitsByType(string type); // Car vs Moto
        void AddExhibit(Exhibit exhibit);
        void UpdateExhibit(Exhibit exhibit);
        void DeleteExhibit(Guid id);
        Exhibit GetExhibitById(Guid id);
    }
}
