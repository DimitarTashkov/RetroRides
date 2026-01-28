using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.DTOs.User
{
    public class UserDataViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string AvatarUrl { get; set; }
    }
}
