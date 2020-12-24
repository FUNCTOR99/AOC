using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day24Part2 : AOCProblem
    {

        public AOC2020Day24Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<Point> tiles = new List<Point>();

            foreach (String line in input)
            {
                List<string> directions = ParseDirections(line);

                ProcessDirections(ref tiles, directions);
            }

            int numDays = 100;
            int currentDay = 1;

            while (currentDay <= numDays)
            {
                int minX = tiles.Min(p => p.Y) - 2;
                int maxX = tiles.Max(p => p.Y) + 2;

                int minY = tiles.Min(p => p.Y) - 1;
                int maxY = tiles.Max(p => p.Y) + 1;

                List<Point> tilesToRemove = new List<Point>();
                List<Point> tilesToAdd = new List<Point>();


                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = minY; y < maxY; y++)
                    {
                        //maybe add an if statement to eliminate shifted X shearches which will always fail.
                        Point point = new Point(x, y);
                        int adjacentBlackTiles = AdjacentBlackTiles(ref tiles, point);

                        if (tiles.Contains(point))
                        {
                            if ((adjacentBlackTiles == 0) || (adjacentBlackTiles > 2))
                            {
                                tilesToRemove.Add(point);
                            }
                        }
                        else 
                        {
                            if (adjacentBlackTiles == 2)
                            {
                                tilesToAdd.Add(point);
                            }
                        }
                    }
                }

                foreach (Point point in tilesToAdd)
                {
                    tiles.Add(point);
                }

                foreach (Point point in tilesToRemove)
                {
                    tiles.Remove(point);
                }

                Console.WriteLine($"After Day {currentDay}, there are {tiles.Count()} Black Tiles.");

                currentDay++;
            }





            return $"Result { tiles.Count }.";
        }

        private int AdjacentBlackTiles(ref List<Point> tiles, Point point)
        {
            int count = 0;

            // ne
            if (tiles.Contains(new Point(point.X + 1, point.Y + 1)))
                count++;

            // e
            if (tiles.Contains(new Point(point.X + 2, point.Y)))
                count++;

            // se
            if (tiles.Contains(new Point(point.X + 1, point.Y - 1)))
                count++;

            // sw
            if (tiles.Contains(new Point(point.X - 1, point.Y - 1)))
                count++;

            // w
            if (tiles.Contains(new Point(point.X - 2, point.Y)))
                count++;

            // nw
            if (tiles.Contains(new Point(point.X - 1, point.Y + 1)))
                count++;

            return count;
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

        private List<string> ParseDirections(string input)
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
