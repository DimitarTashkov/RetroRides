using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Common.Constants
{
    public class FontsPicker
    {
        public static Font BaseFont = new Font("Verdana", 12, FontStyle.Italic | FontStyle.Bold);
        public static Font DetailsFont = new Font("Verdana", 10, FontStyle.Italic | FontStyle.Bold);
        public static Font ErrorMessagesFont = new Font("Verdana", 8, FontStyle.Underline | FontStyle.Bold);

        public static Font UnauthorisedBaseFont = new Font("Verdana", 12, FontStyle.Italic | FontStyle.Bold | FontStyle.Strikeout);
        public static Font UnauthorisedDetailsFont = new Font("Verdana", 10, FontStyle.Italic | FontStyle.Bold | FontStyle.Strikeout);
        public static Font HeadersFont = new Font("Verdana", 16, FontStyle.Italic);
    }
}
