using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    internal class RoundRect:Shape
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int Y3 { get; set; }
        public Color color { get; set; }

        public RoundRect(int x1, int x2, int y1, int y2, int x3, int y3,Color color)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
            this.color= color;
        }
   
        public override void Draw(Graphics g)
        {
            Point[] points = {
   new Point(X,Y),
   new Point(X1,Y1),
   new Point(X2,Y2),
   new Point(X3,Y3),
   };
            Pen pen = new Pen(color,3);
            g.DrawClosedCurve(pen, points);
        }
    }
}
