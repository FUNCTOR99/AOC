using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day03Part2 : AOCProblem
    {

        public AOC2020Day03Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<String> grid = new List<string>();

            foreach (String line in input)
            {
                grid.Add(line);

            }

            Int64 treeProduct = TreesEncountered(grid, 1, 1);
            treeProduct = treeProduct * TreesEncountered(grid, 3, 1);
            treeProduct = treeProduct * TreesEncountered(grid, 5, 1);
            treeProduct = treeProduct * TreesEncountered(grid, 7, 1);
            treeProduct = treeProduct * TreesEncountered(grid, 1, 2);

            return $"Trees Encountered Product = { treeProduct }.";
        }

        private Int64 TreesEncountered(List<string> treeGrid, int slopeRight, int slopeDown)
        {
            Int64 treeCount = 0;
            int x = 0;

            for (int y = slopeDown; y < treeGrid.Count; y = y + slopeDown)
            {
                if (y < treeGrid.Count)
                {
                    x = (x + slopeRight) % treeGrid[0].Length;

                    if (treeGrid[y].ToCharArray()[x] == '#')
                        treeCount++;
                }
            }

            return treeCount;
        }
        
    }
}
