using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day11Part1 : AOCProblem
    {
        public AOC2020Day11Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int result = 0;

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
                        if (IsEmpty(grid[i - 1][j - 1]) && IsEmpty(grid[i - 1][j]) && IsEmpty(grid[i - 1][j + 1]) &&
                            IsEmpty(grid[i][j - 1]) && IsEmpty(grid[i][j + 1]) &&
                            IsEmpty(grid[i + 1][j - 1]) && IsEmpty(grid[i + 1][j]) && IsEmpty(grid[i + 1][j + 1]))
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

                        if (!IsEmpty(grid[i - 1][j - 1]))
                            adjCount++;
                        if (!IsEmpty(grid[i - 1][j]))
                            adjCount++;
                        if (!IsEmpty(grid[i - 1][j + 1]))
                            adjCount++;
                        if (!IsEmpty(grid[i][j - 1]))
                            adjCount++;
                        if (!IsEmpty(grid[i][j + 1]))
                            adjCount++;
                        if (!IsEmpty(grid[i + 1][j - 1]))
                            adjCount++;
                        if (!IsEmpty(grid[i + 1][j]))
                            adjCount++;
                        if (!IsEmpty(grid[i + 1][j + 1]))
                            adjCount++;

                        if (adjCount >= 4)
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
    }
}
