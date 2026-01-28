using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Utilities
{
    public class LayoutHelper
    {
        public static void set_FormBackground(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Panel panel = sender as Panel;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, panel.Width, panel.Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(43, 8, 120), Color.FromArgb(214, 58, 249), LinearGradientMode.ForwardDiagonal );

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
