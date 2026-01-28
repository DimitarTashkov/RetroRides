using RetroRides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services.Interfaces
{
    public interface ISouvenirService 
    {
        List<Souvenir> GetAllSouvenirs();
        Souvenir GetSouvenirById(Guid id);
        void PurchaseItem(Guid userId, Guid souvenirId, int quantity);
    }
}
