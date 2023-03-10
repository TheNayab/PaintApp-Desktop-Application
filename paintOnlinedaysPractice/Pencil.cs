using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    internal class Pencil:Shape
    {
        public Point Px { get; set; }
        public Point Py { get; set; }
        
       

        public override void Draw(Graphics g)
        {
            Pen pen=new Pen(Color.Black);
            g.DrawLine(pen, Px,Py);
        }
    }
}
