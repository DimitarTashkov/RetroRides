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
using System.Text;

namespace RetroRides.Services
{
    public class ShopService : BaseService, IShopService
    {
        private readonly PrismContext context;

        public ShopService(PrismContext context)
        {
            this.context = context;
        }

        // --- ПРОДУКТИ ---

        public List<Product> GetAllProducts()
        {
            return this.context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return this.context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(string name, string description, decimal price, int stock, string imageUrl)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                StockQuantity = stock,
                ImageUrl = imageUrl
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.context.Products.Find(id);
            if (product != null)
            {
                this.context.Products.Remove(product);
                this.context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            // Важно: Update в EF Core понякога е трики, това е най-сигурният начин:
            var existing = context.Products.Find(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.StockQuantity = product.StockQuantity;
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl; // Ако се е сменила снимката

                context.SaveChanges();
            }
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateStock(Guid productId, int newQuantity)
        {
            var product = this.context.Products.Find(productId);
            if (product != null)
            {
                product.StockQuantity = newQuantity;
                this.context.SaveChanges();
            }
        }
        public void CompleteOrder(Guid orderId)
        {
            var order = context.Orders.Find(orderId);
            if (order != null)
            {
                // За простота в дипломната работа: Приемаме, че щом е изпълнена, 
                // я махаме от списъка с активни задачи (или я трием).
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        // --- ПОРЪЧКИ ---

        public Guid CreateOrder(Guid userId, Dictionary<Guid, int> cartItems, string address, string phone)
        {
            // 1. Създаваме самата поръчка
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                DeliveryAddress = address,
                PhoneNumber = phone,
                IsShipped = false,
                TotalAmount = 0 // Ще го сметнем долу
            };

            decimal totalAmount = 0;

            // 2. Добавяме продуктите
            foreach (var item in cartItems)
            {
                Guid productId = item.Key;
                int quantity = item.Value;

                var product = this.context.Products.Find(productId);

                if (product != null)
                {
                    // Проверка за наличност
                    if (product.StockQuantity < quantity)
                    {
                        throw new Exception($"Няма достатъчно наличност от {product.Name}. Налични: {product.StockQuantity}");
                    }

                    // Намаляваме наличността в склада!
                    product.StockQuantity -= quantity;

                    // Добавяме реда към поръчката
                    var orderItem = new OrderItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = product.Price,
                        Order = order
                    };

                    this.context.OrderItems.Add(orderItem);
                    totalAmount += (product.Price * quantity);
                }
            }

            order.TotalAmount = totalAmount;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return order.Id; // Връщаме ID-то, за да можем да покажем фактурата
        }

        public List<Order> GetUserOrders(Guid userId)
        {
            return this.context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public List<Order> GetAllOrders()
        {
            return this.context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        // --- ФАКТУРИРАНЕ ---

        public string GenerateInvoiceText(Guid orderId)
        {
            var order = this.context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null) return "Поръчката не е намерена.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("========================================");
            sb.AppendLine("             ФАКТУРА ОРИГИНАЛ           ");
            sb.AppendLine("========================================");
            sb.AppendLine($"№ на фактура: {order.Id}");
            sb.AppendLine($"Дата: {order.OrderDate.ToString("dd.MM.yyyy HH:mm")}");
            sb.AppendLine($"Клиент: {order.User.Username}");
            sb.AppendLine($"Телефон: {order.PhoneNumber}");
            sb.AppendLine($"Адрес за доставка: {order.DeliveryAddress}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("СТОКИ:");

            foreach (var item in order.OrderItems)
            {
                string line = $"{item.Product.Name} x {item.Quantity} бр.";
                string price = $"{item.Quantity * item.UnitPrice:F2} лв.";
                sb.AppendLine($"{line,-30} {price,8}");
            }

            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"ОБЩА СУМА ЗА ПЛАЩАНЕ:       {order.TotalAmount:F2} лв.");
            sb.AppendLine("========================================");
            sb.AppendLine("Благодарим Ви, че избрахте нашето студио!");

            return sb.ToString();
        }
    }
}