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
            //List<int> cups = new List<int>();
            LinkedList<int> llCups = new LinkedList<int>();

            foreach (String line in input)
            {
                foreach (char cup in line)
                {
                    llCups.AddLast(Convert.ToInt32(cup.ToString()));
                }
            }

            for (int i = llCups.Max() + 1; i <= 1000000; i++)
            {
                llCups.AddLast(i);
            }


            int currentIndex = 0;
            int iterations = 10000000;
            int currentIteration = 0;

            int min = llCups.Min();
            int max = llCups.Max();
            int cupCount = llCups.Count();

            LinkedListNode<int> currentValue = llCups.First;

            while (currentIteration < iterations)
            {
                //int currentValue = cups[currentIndex];

                List<int> next3Values = NextValues(ref llCups, currentValue, 3);

                foreach (int cup in next3Values)
                {
                    llCups.Remove(cup);
                }

                //int cup1 = //cups[CircularIndex(cupCount, currentIndex + 1)];
                //int cup2 = cups[CircularIndex(cupCount, currentIndex + 2)];
                //int cup3 = cups[CircularIndex(cupCount, currentIndex + 3)];

                //cups.Remove(cup1);
                //cups.Remove(cup2);
                //cups.Remove(cup3);

                LinkedListNode<int> destinationNode = DestinationCupIndex(ref llCups, currentValue);

                foreach (int cup in next3Values)
                {
                    LinkedListNode<int> newNode = llCups.AddAfter(destinationNode, cup);

                    destinationNode = newNode;
                }

                //InsertOrAdd(ref cups, destinationIndex + 1, cup1);
                //InsertOrAdd(ref cups, destinationIndex + 2, cup2);
                //InsertOrAdd(ref cups, destinationIndex + 3, cup3);

                //currentIndex = CircularIndex(cupCount, cups.IndexOf(currentValue) + 1);

                currentValue = NextNode(ref llCups, currentValue);

                currentIteration++;
            }

            long result = (long)llCups.Find(1).Next.Value * (long)llCups.Find(1).Next.Next.Value;

            return $"Result { result }.";
        }

        private LinkedListNode<int> NextNode(ref LinkedList<int> list, LinkedListNode<int> node)
        {
            if (node.Next == null)
                return list.First;
            else
                return node.Next;
        }

        private List<int> NextValues(ref LinkedList<int> list, LinkedListNode<int> node, int numberOfValues)
        {
            List<int> values = new List<int>();

            //LinkedListNode<int> currentValue = list.Find(value);
            LinkedListNode<int> nextValue;

            for (int i = 0; i < numberOfValues; i++)
            {
                if (node.Next != null)
                {
                    nextValue = node.Next;
                }
                else
                {
                    nextValue = list.First;
                }

                values.Add(nextValue.Value);

                node = nextValue;
            }

            return values;
        }

        private int CircularIndex(int numItems, int index)
        {
            return (index + numItems) % numItems;
        }

        private LinkedListNode<int> DestinationCupIndex(ref LinkedList<int> cups, LinkedListNode<int> node) //, int globalMin, int globalMax)
        {
            LinkedListNode<int> destinationNode = null; 

            for (int i = 1; i <= 3; i++)
            {
                destinationNode = cups.Find(node.Value - i);

                if (destinationNode != null)
                    break;
            }

            if (destinationNode == null)
            {
                destinationNode = cups.Find(cups.Max());
            }

            return destinationNode;


            //int destinationCupValue = 0;
            //int destinationCupIndex = -1;

            //destinationCupIndex = cups.IndexOf(node.Value - 1);

            //if (destinationCupIndex >= 0)
            //{
            //    return destinationCupIndex;
            //}
            //else
            //{
            //    //if (value > globalMin)
            //        if (value > cups.Min())
            //    { 
            //        destinationCupValue = cups.Where(i => i < value).OrderByDescending(j => j).First();
            //    }
            //    else
            //    {
            //        destinationCupValue = cups.Max();
            //    }

            //    return cups.IndexOf(destinationCupValue);
            //}
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

        private void InsertToLinkedList(ref LinkedList<int> list, LinkedListNode<int> destinationNode, int value)
        {
            list.AddAfter(destinationNode, value);
        }
    }
}
