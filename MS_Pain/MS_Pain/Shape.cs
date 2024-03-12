using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Pain
{
    internal class Shape
    {
        public List<Point> line;
        public float size;
        public Color color;

        public Shape(List<Point> line, float size, Color color)
        {
            this.line = line;
            this.size = size;
            this.color = color;
        }
    }
}
