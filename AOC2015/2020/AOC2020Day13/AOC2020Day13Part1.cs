using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day13Part1 : AOCProblem
    {
        public AOC2020Day13Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int result = 0;

            long busID = Convert.ToInt64(input[0]);
            string[] busSched = input[1].Split(',');

            long earliest = long.MaxValue;
            long earliestBusID = 0;

            foreach (string bus in busSched)
            {
                if (bus.Equals("x") == false)
                {
                    long busTime = Convert.ToInt64(bus);
                    long currentTime = busTime;

                    while (currentTime < busID)
                    {
                        currentTime = currentTime + busTime;
                    }

                    if (currentTime < earliest)
                    {
                        earliest = currentTime;
                        earliestBusID = busTime;
                    }


                }
            }

            long answer = earliestBusID * (earliest - busID);

           



            return $"Result { answer }.";            

        }

        


    }
}
