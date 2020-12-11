using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day10Part1 : AOCProblem
    {
        public AOC2020Day10Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<int> adapters = new List<int>();

            adapters.Add(0);

            foreach (String line in input)
            {
                adapters.Add(Convert.ToInt32(line));
            }

            adapters.Add(adapters.Max() + 3);

            adapters.Sort();

            int diff1Count = 0;
            int diff2Count = 0;
            int diff3Count = 0;

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                int diff = adapters[i + 1] - adapters[i];

                switch (diff)
                {
                    case 1:
                        diff1Count++;
                        break;
                    case 2:
                        diff2Count++;
                        break;
                    case 3:
                        diff3Count++;
                        break;
                }
            }

            return $"Result { diff1Count * diff3Count }.";

        }
    }
}
