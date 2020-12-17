using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Point4D : IPoint4D
    {
        public int W { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point4D(int w, int x, int y, int z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
