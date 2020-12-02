using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Path<T> : IPath<T>
    {
        public List<T> Ends { get; }
        public Int32 Distance { get; }

        public Path(T end1, T end2, Int32 distance)
        {
            Ends = new List<T>();
            Ends.Add(end1);
            Ends.Add(end2);

            Distance = distance;
        }
    }
}
