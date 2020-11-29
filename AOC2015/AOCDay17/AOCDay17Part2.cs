using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay17Part2 : AOCProblem
    {
        public AOCDay17Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            List<int> containers = new List<int>();

            //get the input
            foreach (String line in input)
            {
                containers.Add(Convert.ToInt32(line));
            }

            //Check Container Combos
            int totalVolume = 150;
            List<int> containersThatSumToVolume = new List<int>();

            for (int i = 0; i < Math.Pow(2, containers.Count()); i++)
            {
                int containerVolume = 0;

                for (int j = 0; j < containers.Count(); j++)
                {
                    int containerIncluded = i & (1 << j);

                    if (j < containers.Count() && (containerIncluded > 0))
                        if (containerIncluded > 0)
                            containerVolume = containerVolume + containers[j];
                        else
                            break;

                    if (containerVolume > totalVolume)
                        break;
                }

                if (containerVolume == totalVolume)
                    containersThatSumToVolume.Add(i);
            }

            //find the fewest containers to sum to 150
            int minContainers = int.MaxValue;

            foreach (int combo in containersThatSumToVolume)
            {
                int numContainers = Binary.CountSetBits(combo);
                
                if (numContainers < minContainers)
                {
                    minContainers = numContainers;
                }
            }

            //find how many combinations have this minimum number of containers
            int numberOfCombinations = 0;

            foreach (int combo in containersThatSumToVolume)
            {
                int numContainers = Binary.CountSetBits(combo);

                if (numContainers == minContainers)
                {
                    numberOfCombinations++;
                }
            }

            return $"There are {numberOfCombinations} combinations that have {minContainers} containers.";

        }

        
      
    }
}
