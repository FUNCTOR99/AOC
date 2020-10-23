using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay1Part1 : IAOCProblem
    {
        String[] _input;

        IStandardMessages _standardMessages;

        public AOCDay1Part1(String[] input, IStandardMessages standardMessages)
        {
            _input = input;
            _standardMessages = standardMessages;
        }

        public void Solve()
        {
            _standardMessages.StartingProblem();

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

            _standardMessages.ProblemAnswered($"Santa is on floor { currentFloor }.");
            
        }
    }
}
