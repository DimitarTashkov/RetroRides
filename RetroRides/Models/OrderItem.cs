using RetroRides.Data.Models;
using RetroRides.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetroRides.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(Souvenir))]
        public int SouvenirId { get; set; }
        public virtual Souvenir Souvenir { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}