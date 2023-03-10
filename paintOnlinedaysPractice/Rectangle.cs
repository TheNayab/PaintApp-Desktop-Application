using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintOnlinedaysPractice
{
    internal class RRectangle:Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color color { get; set; }
        public RRectangle(int width, int height, Color color)
        {
            Width = width; Height = height;
            this.color = color;
        }

        public override void Draw(Graphics g)
        {
            
            Pen pen = new Pen(color,3);
            g.DrawRectangle(pen, X, Y, Width, Height);
        }
    }
}
