using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2015
{
    public class AOC2020Day10Part2 : AOCProblem
    {

        public AOC2020Day10Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            Console.WriteLine(DateTime.Now);

            List<int> adapters = new List<int>();

            adapters.Add(0);

            foreach (String line in input)
            {
                adapters.Add(Convert.ToInt32(line));
            }

            adapters.Add(adapters.Max() + 3);

            adapters.Sort();

            bool previousMandatory = true;
            int treeStart = 0;
            int treeEnd = adapters.Count() - 1;

            bool treeStartFound = false;
            bool treeEndFound = false;

            long leafProduct = 1;

            for (int i = 1; i < adapters.Count() - 1; i++)
            {
                if (adapters[i+1] - adapters[i-1] > 3)
                {   
                    if(previousMandatory == false)
                    {
                        treeEnd = i;
                        treeEndFound = true;
                    }
                    previousMandatory = true;
                }
                else
                {
                    if (previousMandatory)
                    {
                        treeStart = i - 1;
                        treeStartFound = true;
                        previousMandatory = false;
                    }
                }

                if (treeStartFound && treeEndFound)
                {
                    List<int> values = new List<int>();

                    for (int j = treeStart; j <= treeEnd; j++)
                    {
                        values.Add(adapters[j]);
                    }

                    IAdapterTree tree = Factory.CreateAdapterTree(values.ToArray());

                    leafProduct = leafProduct * tree.LeafCount;

                    treeStartFound = false;
                    treeEndFound = false;
                }
            }


            Console.WriteLine(DateTime.Now);

            return $"Result {leafProduct}.";
        }                
    }
}
