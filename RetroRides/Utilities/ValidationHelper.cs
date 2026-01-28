using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetroRides.Utilities
{
    public class ValidationHelper
    {
        public static bool ValidateUserInputs(List<TextBox> textboxes,RoundPictureBox pfp)
        {
            if(textboxes.Any(t => t.Text == "" || t.TextLength < 1) || pfp.ImageLocation == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUserInputs(List<TextBox> textboxes, PictureBox pfp)
        {
            if (textboxes.Any(t => t.Text == "" || t.TextLength < 1) || pfp.ImageLocation == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUserInputs(List<TextBox> textboxes)
        {
            if (textboxes.Any(t => t.Text == "" || t.TextLength < 1))
            {
                return false;
            }
            return true;
        }
        public static int ValidateUserAge(TextBox ageField)
        {
            int age;
            if (ageField.Text.Any(c => !char.IsDigit(c)) || ageField.Text == "")
            {
                age = 0;
            }
            else
            {
                age = int.Parse(ageField.Text);
            }
            return age;
        }
        public static bool ValidateNumerics(List<TextBox> textboxes)
        {
            Regex matchNumbers = new Regex(@"[\d+\.\d{2,3}]");

            if(textboxes.Any(t => !matchNumbers.IsMatch(t.Text)))
            {
                return false;
            }
            return true;
        }

    }
}
