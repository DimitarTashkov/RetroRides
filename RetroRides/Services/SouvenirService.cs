using RetroRides.Data;
using RetroRides.Data.Models;
using RetroRides.Models;
using RetroRides.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services
{
    public class SouvenirService : ISouvenirService
    {
        private readonly MuseumContext _context;

        public SouvenirService(MuseumContext context)
        {
            _context = context;
        }

        public List<Souvenir> GetAllSouvenirs()
        {
            return _context.Souvenirs.ToList();
        }

        public Souvenir GetSouvenirById(Guid id)
        {
            return _context.Souvenirs.Find(id);
        }

        public void PurchaseItem(Guid userId, Guid souvenirId, int quantity)
        {
            var souvenir = _context.Souvenirs.Find(souvenirId);

            if (souvenir != null && souvenir.StockQuantity >= quantity)
            {
                // 1. Намаляваме наличността
                souvenir.StockQuantity -= quantity;

                // 2. Създаваме поръчка (опростено: 1 поръчка = 1 вид продукт за момента)
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    TotalAmount = souvenir.Price * quantity
                };

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    SouvenirId = souvenirId,
                    Quantity = quantity,
                    UnitPrice = souvenir.Price
                };

                _context.Orders.Add(order);
                _context.OrderItems.Add(orderItem);

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Not enough stock available.");
            }
        }
        public void AddSouvenir(Souvenir souvenir)
        {
            if (souvenir.Id == Guid.Empty) souvenir.Id = Guid.NewGuid();
            _context.Souvenirs.Add(souvenir);
            _context.SaveChanges();
        }

        public void UpdateSouvenir(Souvenir souvenir)
        {
            var existing = _context.Souvenirs.Find(souvenir.Id);
            if (existing != null)
            {
                existing.Name = souvenir.Name;
                existing.Price = souvenir.Price;
                existing.StockQuantity = souvenir.StockQuantity;
                existing.ImagePath = souvenir.ImagePath;
                _context.SaveChanges();
            }
        }

        public void DeleteSouvenir(Guid id)
        {
            var item = _context.Souvenirs.Find(id);
            if (item != null)
            {
                _context.Souvenirs.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
