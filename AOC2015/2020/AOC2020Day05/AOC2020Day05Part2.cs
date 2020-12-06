using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day05Part2 : AOCProblem
    {

        public AOC2020Day05Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int result = 0;

            List<int> seatIDs = new List<int>();

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

                seatIDs.Add(seatID);
            }

            seatIDs.Sort();

            for (int i = 0; i < seatIDs.Count - 1; i++)
            {
                if (seatIDs[i + 1] != (seatIDs[i] + 1))
                {
                    result = seatIDs[i] + 1;
                    break;
                }
            }


            return $"Result { result }.";
        }

        
    }
}
