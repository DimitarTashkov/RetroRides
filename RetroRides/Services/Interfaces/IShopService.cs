using RetroRides.Data.Models; // Увери се в namespace-а
using System.Collections.Generic;

namespace RetroRides.Services.Interfaces
{
    public interface IShopService
    {
        // Методи за продукти
        List<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void AddProduct(string name, string description, decimal price, int stock, string imageUrl);
        void DeleteProduct(Guid id);
        void UpdateStock(Guid productId, int newQuantity);

        // Методи за поръчки
        Guid CreateOrder(Guid userId, Dictionary<Guid, int> cartItems, string address, string phone);
        List<Order> GetUserOrders(Guid userId);
        List<Order> GetAllOrders(); // За админа

        // Генериране на фактура
        string GenerateInvoiceText(Guid orderId);
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        void CompleteOrder(Guid orderId);
    }
}