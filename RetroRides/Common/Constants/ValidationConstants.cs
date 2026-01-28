using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Common.Constants
{
    public static class ValidationConstants
    {
        public static class ServiceConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int DescriptionMaxLength = 200;
            public const int DescriptionMinLength = 3;
        }
        public static class UserConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int PasswordMaxLength = 50;
            public const int PasswordMinLength = 5;
        }
        public static class InputConstants
        {
            public const string DialogFilter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All files(*.*)|*.*";
        }
        public static class ReviewConstants
        {
            public const int MessageMinLength = 5;
            public const int MessageMaxLength = 100;
            public const int RatingMinRange = 0;
            public const int RatingMaxRange = 5;
        }
    }
}
