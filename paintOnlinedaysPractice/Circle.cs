using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    internal class Circle:Shape
    {
        public int Radius
        {
            get; set;
        }
        public Color color { get; set; }
       public Circle(int radius, Color color)
        {
            Radius = radius;
            this.color = color;
        }

        public override void Draw(Graphics g)
        {
            Pen pen =new Pen(color,3);  
            
            g.DrawEllipse(pen, X, Y, Radius, Radius);
        }
    }
}
