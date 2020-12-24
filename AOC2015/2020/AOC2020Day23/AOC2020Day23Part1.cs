using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day23Part1 : AOCProblem
    {
        public AOC2020Day23Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<int> cups = new List<int>();

            foreach (String line in input)
            {
               foreach(char cup in line)
                {
                    cups.Add(Convert.ToInt32(cup.ToString()));
                }
            }


            int currentIndex = 0;
            int iterations = 100;
            int currentIteration = 0;

            while (currentIteration < iterations)
            {
                int currentValue = cups[currentIndex];

                int cup1 = cups[CircularIndex(cups.Count(), currentIndex + 1)];
                int cup2 = cups[CircularIndex(cups.Count(), currentIndex + 2)];
                int cup3 = cups[CircularIndex(cups.Count(), currentIndex + 3)];

                cups.Remove(cup1);
                cups.Remove(cup2);
                cups.Remove(cup3);

                int destinationIndex = DestinationCupIndex(cups, currentValue);

                InsertOrAdd(ref cups, destinationIndex + 1, cup1);
                InsertOrAdd(ref cups, destinationIndex + 2, cup2);
                InsertOrAdd(ref cups, destinationIndex + 3, cup3);

                currentIndex = CircularIndex(cups.Count(), cups.IndexOf(currentValue) + 1);
                currentIteration++;
            }


            StringBuilder sb = new StringBuilder();
            int index1 = cups.IndexOf(1);

            for (int i = 1; i < cups.Count(); i++)
            {
                sb.Append(cups[CircularIndex(cups.Count(), index1 + i)]);
            }       

            return $"Result { sb.ToString() }.";        
        }    
        
        private int CircularIndex(int numItems, int index)
        {
            return (index + numItems) % numItems;
        }

        private int DestinationCupIndex(List<int> cups, int value)
        {
            int destinationCupValue = 0;

            if (value > cups.Min())
            {
                destinationCupValue = cups.Where(i => i < value).OrderByDescending(j => j).First();
            }
            else
            {
                destinationCupValue = cups.Max();
            }

            return cups.IndexOf(destinationCupValue);
        }

        private void InsertOrAdd(ref List<int> list, int index, int value)
        {
            if (index == list.Count)
            {
                list.Add(value);
            }
            else
            {
                list.Insert(CircularIndex(list.Count, index), value);
            }
        }
    }
}
