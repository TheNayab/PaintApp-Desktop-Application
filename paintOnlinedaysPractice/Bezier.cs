using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    internal class Bezier:Shape
    {
    
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int E1 { get; set; }
        public int E2 { get; set; }

        public Color color { get; set; }

        public Bezier(int c1, int c2, int c3, int c4, int e1, int e2 ,Color color)
        {
          
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            E1 = e1;
            E2 = e2;
            this.color = color;
        }

        public override void Draw(Graphics g)
        {
            Pen pen=new Pen(color,3);
            g.DrawBezier(pen, X, Y, C1, C2, C3, C4, E1, E2);
        }
    }
}
