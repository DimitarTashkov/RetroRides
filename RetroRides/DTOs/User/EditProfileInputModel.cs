using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static RetroRides.Common.Constants.ValidationConstants.UserConstants;
using static RetroRides.Common.Messages.ErrorMessages.UserMessages;

namespace RetroRides.DTOs.User
{
    public class EditProfileInputModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = UsernameIsRequired)]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = PasswordIsRequired)]
        [MinLength(PasswordMinLength)]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; } = null!;

        public int? Age { get; set; }

        [Required(ErrorMessage = EmailIsRequired)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = AvatarIsRequired)]
        public string AvatarUrl { get; set; } = null!;
    }
}
