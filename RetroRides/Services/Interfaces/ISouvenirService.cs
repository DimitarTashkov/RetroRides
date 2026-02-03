using RetroRides.Data.Models;
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
        void PurchaseItem(Guid userId, Guid souvenirId, int quantity, string address, string phone);
        void AddSouvenir(Souvenir souvenir);
        void UpdateSouvenir(Souvenir souvenir);
        void DeleteSouvenir(Guid id);
        List<Order> GetOrdersByUserId(Guid userId); // За клиента
        List<Order> GetAllOrders(); // За админа
        void DeleteOrder(Guid id);


    }
}
