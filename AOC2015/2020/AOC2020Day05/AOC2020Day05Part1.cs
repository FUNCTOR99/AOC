using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day05Part1 : AOCProblem
    {
        public AOC2020Day05Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int validCount = 0;

            int max = 0;

            foreach (String line in input)
            {
                string row = line.Substring(0, 7);
                string seat = line.Substring(7, 3);

                row = row.Replace('B', '1');
                row = row.Replace('F', '0');

                int i_row = Convert.ToInt32(row, 2);

                seat = seat.Replace('R', '1');
                seat = seat.Replace('L', '0');

                int i_seat = Convert.ToInt32(seat, 2);

                int seatID = (i_row * 8) + i_seat;

                if (seatID > max)
                    max = seatID;
            }

            



            return $"Result { max }.";
            
        }
    }
}
