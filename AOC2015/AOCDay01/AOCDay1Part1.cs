using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay1Part1 : IAOCProblem
    {
        public AOCDay1Part1(string[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override string doSolve()
        {
            int currentFloor = 0;

            foreach (String line in _input)
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
