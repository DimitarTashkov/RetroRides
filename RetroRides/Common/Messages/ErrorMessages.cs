 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Common.Messages
{
    public static class ErrorMessages
    {
        public static class RoomMessages
        {
            public const string RoomTypeIsRequired = "Selecting room type is required";
            public const string PriceIsRequired = "Defining price is required";
            public const string IsAvailableRequired = "Room status is required";
            public const string RoomPictureRequired = "Room picture is required";
            public const string RoomNumberRequired = "Room number is required";
            public const string RoomNumberExists = "Such room number already exists";

        }
        public static class UserMessages
        {
            public const string UsernameIsRequired = "Username is required";
            public const string PasswordIsRequired = "Password is required";
            public const string EmailIsRequired = "Email is required";
            public const string AvatarIsRequired = "Profile picture is required";
            public const string InvalidUserCredentials = "Invalid username or password!";
            public const string UsernameExists = "Such username already exists!";

        }

        public static class ServicesMessages
        {
            public const string ServiceNameIsRequired = "Service name is required";
            public const string ServiceDescriptionIsRequired = "Service description is required";
        }
        public static class ReviewsMessages
        {
            public const string MessageIsRequired = "Message is required for reviews!";
        }
    }
}
