using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay05Part1 : AOCProblem
    {
        public AOCDay05Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int niceStringCount = 0;
            String[] notContain = { "ab", "cd", "pq", "xy" };

            foreach (String inputLine in input)
            {
                if ((Validation.StringVowelCount(inputLine) >= 3)
                    && (Validation.StringRepeatedLetter(inputLine) == true)
                    && (Validation.StringDoesNotContainStrings(inputLine, notContain)))
                {
                    niceStringCount++;
                }
            }

            return $"There are {niceStringCount} nice strings.";
            
        }
    }
}
