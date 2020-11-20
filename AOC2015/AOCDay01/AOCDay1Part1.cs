using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay1Part1 : AOCProblem
    {
        public AOCDay1Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int currentFloor = 0;

            foreach (String line in input)
            {             
                foreach (char x in line)
                {
                    if (x == '(')
                        currentFloor++;
                    else if (x == ')')
                        currentFloor--;
                }
                
            }

            return $"Santa is on floor { currentFloor }.";
            
        }
    }
}
