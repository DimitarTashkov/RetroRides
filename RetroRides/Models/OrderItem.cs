using RetroRides.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetroRides.Data.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; } // Колко бройки от този продукт

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Цена към момента на поръчката
    }
}