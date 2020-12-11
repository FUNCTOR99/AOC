using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day09Part1 : AOCProblem
    {
        public AOC2020Day09Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            

            List<long> numbers = new List<long>();


            foreach (String line in input)
            {
                numbers.Add(Convert.ToInt64(line));



            }

            bool matchFound = false;
            int noMatchIndex = 0;

            for (int i = 25; i < numbers.Count; i++)
            {
                matchFound = false;

                for (int j = (i - 25); j < i; j++)
                {
                    if (matchFound)
                    {
                        break;
                    }

                    for (int k = (i - 25); k < i; k++)
                    {
                        if (j != k)
                        {
                            if (numbers[j] + numbers[k] == numbers[i])
                            {
                                matchFound = true;
                                break;
                            }

                        }

                    }
                }

                if (!matchFound)
                {
                    noMatchIndex = i;
                }
            }
           




            return $"Result { numbers[noMatchIndex] }.";            

        }
    }
}
