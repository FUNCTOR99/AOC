using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day20Part1 : AOCProblem
    {
        public AOC2020Day20Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<ImageTile> tiles = new List<ImageTile>();

            List<string> currentTile = new List<string>();

            foreach (String line in input)
            {
                if (line.Trim().Length == 0)
                {
                    tiles.Add(new ImageTile(currentTile));
                    currentTile = new List<string>();
                }
                else
                {
                    currentTile.Add(line);
                }
            }

            tiles.Add(new ImageTile(currentTile));




            return $"Result { result }.";        
        }         
        
        


    }
}
