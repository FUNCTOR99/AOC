using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day17Part2 : AOCProblem
    {

        public AOC2020Day17Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<IPoint4D> grid = new List<IPoint4D>();

            int w = 0;
            int y = 1;
            int z = 0;

            foreach (String line in input)
            {
                for (int x = 1; x <= line.Length; x++)
                {
                    if (line[x - 1].Equals('#'))
                    {
                        grid.Add(Factory.CreatePoint4D(w, x, y, z));
                    }
                }

                y++;
            }

            int maxCycles = 6;

            for (int i = 0; i < maxCycles; i++)
            {
                grid = Iterate(ref grid);
            }

            return $"Result { grid.Count() }.";
        }

        private List<IPoint4D> Iterate(ref List<IPoint4D> grid)
        {
            List<IPoint4D> result = new List<IPoint4D>();

            int minW = grid.Min(pt => pt.W);
            int minX = grid.Min(pt => pt.X);
            int minY = grid.Min(pt => pt.Y);
            int minZ = grid.Min(pt => pt.Z);

            int maxW = grid.Max(pt => pt.W);
            int maxX = grid.Max(pt => pt.X);
            int maxY = grid.Max(pt => pt.Y);
            int maxZ = grid.Max(pt => pt.Z);

            for (int w = minW - 1; w <= maxW + 1; w++)
            {
                for (int z = minZ - 1; z <= maxZ + 1; z++)
                {
                    for (int y = minY - 1; y <= maxY + 1; y++)
                    {
                        for (int x = minX - 1; x <= maxX + 1; x++)
                        {
                            IPoint4D point = Factory.CreatePoint4D(w, x, y, z);

                            int neighbourCount = ActiveNeighbours(ref grid, point);

                            if (grid.Any(pt => ((pt.W == point.W) && (pt.X == point.X) && (pt.Y == point.Y) && (pt.Z == point.Z))))
                            {
                                if ((neighbourCount == 2) || (neighbourCount == 3))
                                {
                                    result.Add(point);
                                }
                            }
                            else
                            {
                                if (neighbourCount == 3)
                                {
                                    result.Add(point);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private int ActiveNeighbours(ref List<IPoint4D> grid, IPoint4D point)
        {
            int count = 0;

            for (int w = point.W - 1; w <= point.W + 1; w++)
            {
                for (int z = point.Z - 1; z <= point.Z + 1; z++)
                {
                    for (int y = point.Y - 1; y <= point.Y + 1; y++)
                    {
                        for (int x = point.X - 1; x <= point.X + 1; x++)
                        {
                            if (((w == point.W) && (x == point.X) && (y == point.Y) && (z == point.Z)) == false)
                            {
                                count = count + grid.Where(pt => ((pt.W == w) && (pt.X == x) && (pt.Y == y) && (pt.Z == z))).Count();
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
