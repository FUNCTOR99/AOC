using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Combinations
    {
        public static List<int[]> CombinationsThatSumTo(int[] input, int sumTo)
        {
            List<int[]> results = new List<int[]>();

            bool done = false;
            int currentIndex = input.Count();

            while (done == false)
            {
                //incrament
                input[input.Count() - 1]++;

                if (input[input.Count() - 1] > sumTo)
                {
                    for (int i = input.Count() - 1; i >= 0; i--)
                    {
                        if (input[i] >= sumTo)
                        {
                            input[i] = 0;
                        }
                        else
                        {
                            input[i]++;
                            break;
                        }
                    }
                }

                //check the sum
                int currentSum = 0;
                foreach (int number in input)
                {
                    currentSum = currentSum + number;
                }

                if (currentSum == sumTo)
                {
                    results.Add((int[])input.Clone());
                }
                else if (currentSum > sumTo)
                {
                    input[input.Count() - 1] = sumTo; //ffwd when the sum is already over.
                }


                //check if we are at the end
                bool checkIfDone = true;

                foreach (int number in input)
                {
                    checkIfDone = checkIfDone & (number == sumTo);
                }

                if (checkIfDone == true)
                {
                    done = true;
                }
            }

            return results;
        }
    }
}
