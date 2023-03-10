using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace paintOnlinedaysPractice
{
    internal class Line:Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public Color color { get; set; }
        public Line(int x1, int y1, Color color)
        {
            X1 = x1;
            Y1 = y1;
            this.color = color;
        }

        public override void Draw( Graphics g)
        {
            Pen pen = new Pen(color,3);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawLine(pen,X,Y,X1,Y1);
        }
    }
}
