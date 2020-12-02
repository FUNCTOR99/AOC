using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay1Part2 : AOCProblem
    {

        public AOCDay1Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int currentFloor = 0;
            int currentPosition = 1;
            bool inBasement = false;

            foreach (String line in input)
            {                       
                foreach (char x in line)
                {
                    if (x == '(')           
                        currentFloor++;
                    else if (x == ')')
                        currentFloor--;

                    if (currentFloor < 0)
                    {                        
                        inBasement = true;
                        break;
                    }

                    currentPosition++;
                }

                if (inBasement)
                    break;
            }

            return $"Santa enters the basement on position { currentPosition }.";
        }

        
    }
}
