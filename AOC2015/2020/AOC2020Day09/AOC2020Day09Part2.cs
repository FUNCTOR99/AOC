using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day09Part2 : AOCProblem
    {

        public AOC2020Day09Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

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

            long sumTo = numbers[noMatchIndex];

            long currentSum = 0;
            int currentStart = 0;
            int currentEnd = 0;

            bool sumFound = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                currentStart = i;
                currentSum = 0;

                for (int j = i; j < numbers.Count; j++)
                {
                    currentSum = currentSum + numbers[j];

                    if (currentSum == sumTo)
                    {
                        currentEnd = j;
                        sumFound = true;
                        break;
                    }
                    else if (currentSum > sumTo)
                    {
                        break;
                    }
                }

                if (sumFound)
                {
                    break;
                }
            }


            long min = long.MaxValue;
            long max = long.MinValue;

            for (int i = currentStart; i <= currentEnd; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];

                if (numbers[i] < min)
                    min = numbers[i];
            }


            long encWeakness = min + max;






            return $"Result { encWeakness }.";
        }

        
    }
}
