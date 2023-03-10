using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    
    abstract class Shape
    {
        public  int X { get; set; }
        public  int Y { get; set; }

        public abstract void Draw(Graphics g);
    }
}
