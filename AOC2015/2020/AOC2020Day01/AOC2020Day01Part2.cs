using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day01Part2 : AOCProblem
    {

        public AOC2020Day01Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            List<int> numbers = new List<int>();
            int result = 0;

            foreach (String line in input)
            {
                numbers.Add(Convert.ToInt32(line.Trim()));

            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < numbers.Count; k++)
                        {
                            if ((k != i) && (k != j))
                            {
                                if (numbers[i] + numbers[j] + numbers[k] == 2020)
                                    result = numbers[i] * numbers[j] * numbers[k];

                            }
                        }
                    }
                }
            }

            return $"Santa is on floor { result }.";
        }

        
    }
}
