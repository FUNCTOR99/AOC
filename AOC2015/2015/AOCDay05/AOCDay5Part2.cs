using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay05Part2 : AOCProblem
    {

        public AOCDay05Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int niceStringCount = 0;

            foreach (String inputLine in input)
            {
                if ((Validation.CharPairCount(inputLine) >= 2)
                    && (Validation.CharRepeatsWithOneLetterBetween(inputLine)))
                {
                    niceStringCount++;
                }
            }

            return $"There are {niceStringCount} nice strings.";
        }

        
    }
}
