using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day03Part1 : AOCProblem
    {
        public AOC2020Day03Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<String> grid = new List<string>();

            foreach (String line in input)
            {
                grid.Add(line);                
            }

            int x = 0;
            int treeCount = 0;

            for (int y = 1; y < grid.Count; y++)
            {
                x = (x + 3) % grid[0].Length;

                if (grid[y].ToCharArray()[x] == '#')
                    treeCount++;
            }

            return $"Trees Encountered: { treeCount }.";
            
        }
    }
}
