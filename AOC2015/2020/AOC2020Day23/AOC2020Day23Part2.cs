using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day23Part2 : AOCProblem
    {

        public AOC2020Day23Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;
            int numCups         = 1000000;
            int numIterations   = 10000000;

            List<int> cups = new List<int>();

            foreach (String line in input)
            {
                foreach (char cup in line)
                {
                    cups.Add(Convert.ToInt32(cup.ToString()));
                }
            }

            for (int i = cups.Max() + 1; i <= numCups; i++)
            {
                cups.Add(i);
            }


            int currentIndex = 0;
            int currentIteration = 0;

            while (currentIteration < numIterations)
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


            //StringBuilder sb = new StringBuilder();
            int index1 = cups.IndexOf(1);

            long cupAfter1 = (long) cups[index1 + 1];
            long cup2After1 = (long) cups[index1 + 2];

            //for (int i = 1; i < cups.Count(); i++)
            //{
            //    sb.Append(cups[CircularIndex(cups.Count(), index1 + i)]);
            //}

            return $"Result Cup after 1: {cupAfter1}, 2 Cups after 1: {cup2After1}, Product: { cupAfter1 * cup2After1 }";
        }

        private int CircularIndex(int numItems, int index)
        {
            return (index + numItems) % numItems;
        }

        private int DestinationCupIndex(List<int> cups, int value)
        {
            int destinationCupValue = value - 1;

            int iterationCount = 0;

            while (iterationCount < 3)
            {
                if (cups.Contains(destinationCupValue))
                {
                    return cups.IndexOf(destinationCupValue);
                }
                else
                {
                    destinationCupValue--;
                    iterationCount++;
                }
            }

            if (destinationCupValue <= 0)
                return cups.IndexOf(cups.Max());
            else
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
