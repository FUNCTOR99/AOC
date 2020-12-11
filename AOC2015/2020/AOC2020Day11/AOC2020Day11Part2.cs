using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day11Part2 : AOCProblem
    {

        public AOC2020Day11Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<string> seatingGrid = new List<string>();

            bool firstLineAdded = false;
            string blankLine = "";

            foreach (String line in input)
            {

                if (firstLineAdded == false)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append('.');
                    for (int i = 0; i < line.Length; i++)
                    {
                        sb.Append('.');
                    }
                    sb.Append('.');

                    blankLine = sb.ToString();

                    seatingGrid.Add(blankLine);

                    firstLineAdded = true;
                }

                seatingGrid.Add($".{line}.");
            }

            seatingGrid.Add(blankLine);

            bool changesMade = true;

            List<string> nextIteration = new List<string>();

            int currentIteration = 0;

            while (changesMade)
            {
                nextIteration = IterateSeatingGrid(seatingGrid);

                changesMade = !Equals(seatingGrid, nextIteration);

                seatingGrid = nextIteration;

                currentIteration++;
            }

            int seatCount = SeatCount('#', nextIteration);


            return $"Result {seatCount }.";
        }

        private List<String> IterateSeatingGrid(List<String> grid)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < grid.Count(); i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '.')
                        sb.Append('.');
                    else if (grid[i][j] == 'L')
                    {
                        if (IsEmpty(FirstSeat("UL", grid, j, i)) && IsEmpty(FirstSeat("U", grid, j, i)) && IsEmpty(FirstSeat("UR", grid, j, i)) &&
                            IsEmpty(FirstSeat("L", grid, j, i))                                         && IsEmpty(FirstSeat("R", grid, j, i)) &&
                            IsEmpty(FirstSeat("DL", grid, j, i)) && IsEmpty(FirstSeat("D", grid, j, i)) && IsEmpty(FirstSeat("DR", grid, j, i)))
                        {
                            sb.Append('#');
                        }
                        else
                        {
                            sb.Append('L');
                        }
                    }
                    else if (grid[i][j] == '#')
                    {
                        int adjCount = 0;

                        if (!IsEmpty(FirstSeat("UL", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("U", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("UR", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("L", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("R", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("DL", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("D", grid, j, i)))
                            adjCount++;
                        if (!IsEmpty(FirstSeat("DR", grid, j, i)))
                            adjCount++;

                        if (adjCount >= 5)
                            sb.Append('L');
                        else
                            sb.Append('#');
                    }
                }

                result.Add(sb.ToString());
            }

            return result;
        }

        private bool IsEmpty(char spot)
        {
            if (spot == '.')
                return true;
            else if (spot == 'L')
                return true;
            else
                return false;
        }

        private bool Equals(List<string> a, List<string> b)
        {
            if (a.Count() != b.Count())
                return false;
            else
            {
                for (int i = 0; i < a.Count(); i++)
                {
                    if (a[i].Equals(b[i]) == false)
                        return false;
                }
            }

            return true;
        }

        private int SeatCount(char status, List<string> seatGrid)
        {
            int count = 0;
            foreach (string seatLine in seatGrid)
            {
                foreach (char seat in seatLine)
                {
                    if (seat == status)
                        count++;
                }
            }

            return count;
        }

        private char FirstSeat(string direction, List<string> grid, int x, int y)
        {
            int i = 0;
            int j = 0;

            switch (direction)
            {
                case "U":
                    for (i = y - 1; i >= 0; i--)
                    {
                        if (grid[i][x] != '.')
                            return grid[i][x];
                    }
                    break;

                case "UR":
                    i = y - 1;
                    j = x + 1;

                    while ((i >= 0) && (j < grid[i].Length))
                    {
                        if (grid[i][j] != '.')
                            return grid[i][j];
                        else
                        {
                            i--;
                            j++;
                        }
                    }
                    break;

                case "R":
                    for (j = x + 1; j < grid[y].Length; j++)
                    {
                        if (grid[y][j] != '.')
                            return grid[y][j];
                    }
                    break;

                case "DR":
                    i = y + 1;
                    j = x + 1;

                    while ((i < grid.Count()) && (j < grid[i].Length))
                    {
                        if (grid[i][j] != '.')
                            return grid[i][j];
                        else
                        {
                            i++;
                            j++;
                        }
                    } 
                    break;

                case "D":
                    for (i = y + 1; i < grid.Count(); i++)
                    {
                        if (grid[i][x] != '.')
                            return grid[i][x];
                    }
                    break;

                case "DL":
                    i = y + 1;
                    j = x - 1;

                    while ((i < grid.Count()) && (j >= 0))
                    {
                        if (grid[i][j] != '.')
                            return grid[i][j];
                        else
                        {
                            i++;
                            j--;
                        }
                    }
                    break;

                case "L":
                    for (j = x - 1; j >= 0; j--)
                    {
                        if (grid[y][j] != '.')
                            return grid[y][j];
                    }
                    break;

                case "UL":
                    i = y - 1;
                    j = x - 1;

                    while ((i >= 0) && (j >= 0))
                    {
                        if (grid[i][j] != '.')
                            return grid[i][j];
                        else
                        {
                            i--;
                            j--;
                        }
                    }
                    break;

            }
            return '.';
        }

    }
}
