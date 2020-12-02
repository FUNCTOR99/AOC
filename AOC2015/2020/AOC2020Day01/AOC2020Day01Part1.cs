using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day01Part1 : AOCProblem
    {
        public AOC2020Day01Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int currentFloor = 0;
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
                        if (numbers[i] + numbers[j] == 2020)
                            result = numbers[i] * numbers[j];

                    }
                }
            }

            return $"Santa is on floor { result }.";
            
        }
    }
}
