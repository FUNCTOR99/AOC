using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day24Part1 : AOCProblem
    {
        public AOC2020Day24Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<Point> tiles = new List<Point>();

            foreach (String line in input)
            {
                List<string> directions = ParseDirections(line);

                ProcessDirections(ref tiles, directions);
            }





            return $"Result { tiles.Count }.";
        }

        private void ProcessDirections(ref List<Point> tiles, List<string> directions)
        {
            //reference point is (0,0)
            int x = 0;
            int y = 0;

            foreach (string direction in directions)
            {
                switch (direction)
                {
                    case "ne":
                        x++;
                        y++;
                        break;

                    case "e":
                        x = x + 2;                        
                        break;

                    case "se":
                        x++;
                        y--;
                        break;

                    case "sw":
                        x--;
                        y--;
                        break;

                    case "w":
                        x = x - 2;
                        break;

                    case "nw":
                        x--;
                        y++;
                        break;
                }
            }

            Point tile = new Point(x, y);

            if (tiles.Contains(tile))
            {
                tiles.Remove(tile);
            }
            else
            {
                tiles.Add(tile);
            }
        }
        
        private List<string> ParseDirections (string input)
        {
            List<string> directions = new List<string>();

            int i = 0;

            while (i < input.Length)
            {

                switch (input[i])
                {
                    case 'n':
                    case 's':
                        directions.Add(input.Substring(i, 2));
                        i++;
                        break;

                    case 'e':
                    case 'w':
                        directions.Add(input.Substring(i, 1));
                        break;                    
                }

                i++;
            }

            return directions;
        }
    }
}
