using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Models
{
    public class Exhibit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; } // e.g. "Ford"

        [Required]
        [MaxLength(50)]
        public string Model { get; set; } // e.g. "Mustang"

        [Required]
        [MaxLength(20)]
        public string Type { get; set; } // "Car" or "Motorcycle"

        public int Year { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string ImagePath { get; set; } // URL or local path

        public bool IsActive { get; set; } = true;
    }       
}
