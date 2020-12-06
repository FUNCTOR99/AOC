using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day06Part1 : AOCProblem
    {
        public AOC2020Day06Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            //code didn't change after 7 minutes.  Problem ended up being input file was incomplete.  :/

            List<char> groupAnswers = new List<char>();

            int sum = 0;

            foreach (String line in input)
            {
                if (line.Length != 0)
                {
                    foreach (char x in line)
                    {
                        if (!groupAnswers.Contains(x))
                        {
                            groupAnswers.Add(x);
                        }
                    }
                }
                else
                {
                    sum = sum + groupAnswers.Count;

                    groupAnswers.Clear();
                }
            }

            sum = sum + groupAnswers.Count;

            return $"Result { sum }.";            

        }
    }
}
