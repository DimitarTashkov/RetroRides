using RetroRides.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetroRides.Data.Models // Смени namespace-а с твоя
{
    public class PhotoService
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Напр. "Сватбена фотосесия", "Портрет"

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int DurationMinutes { get; set; } // Напр. 60, 90, 120 минути

        public string ImageUrl { get; set; } // Път към снимката (корицата)

        // Връзка към резервациите за тази услуга
        public virtual ICollection<PhotoSession> PhotoSessions { get; set; } = new HashSet<PhotoSession>();
    }
}