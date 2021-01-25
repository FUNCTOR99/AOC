using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day23Part3 : AOCProblem
    {

        public AOC2020Day23Part3(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int numCups         = 1000000; // 1000000;
            int numIterations   = 10000000; // 10000000;

            //List<int> cups = new List<int>();
            QuadLinkedListNode<int> qlCupsCurrent = null;
            QuadLinkedListNode<int> qlCupsStart = null;
            QuadLinkedListNode<int> qlCup1 = null;

            //LinkedList<int> llCups = new LinkedList<int>();
            //Dictionary<int, LinkedListNode<int>> dOfLLCups = new Dictionary<int, LinkedListNode<int>>();
            //Dictionary<int, int> cupsByPosition = new Dictionary<int, int>();

            int position = 1;
            QuadLinkedListNode<int> maxCup = null;
            QuadLinkedListNode<int> minCup = null;

            foreach (String line in input)
            {
                foreach (char cup in line)
                {
                    int cupNumber = Convert.ToInt32(cup.ToString());                    

                    if (qlCupsCurrent == null)
                    {
                        qlCupsCurrent = new QuadLinkedListNode<int>(cupNumber);
                        qlCupsStart = qlCupsCurrent;                        
                    }
                    else
                    {
                        qlCupsCurrent = qlCupsCurrent.Add(new QuadLinkedListNode<int>(cupNumber));
                    }

                    if ((maxCup == null) || (cupNumber > maxCup.Value))
                        maxCup = qlCupsCurrent;

                    if ((minCup == null) || (cupNumber < minCup.Value))
                        minCup = qlCupsCurrent;

                    if (cupNumber == 1)
                        qlCup1 = qlCupsCurrent;
                }
            }

            //setup Alternate Links for the initial input
            QuadLinkedListNode<int> maxNode = null;

            for (int i = minCup.Value; i <= maxCup.Value; i++)
            {
                QuadLinkedListNode<int> current = qlCupsStart.Find(i);
                maxNode = current;

                if (i == minCup.Value)
                {
                    //QuadLinkedListNode<int> altPrev = qlCupsStart.Find(maxCup);
                    QuadLinkedListNode<int> altNext = qlCupsStart.Find(i + 1);

                    //current.AltPrev = altPrev;
                    current.AltNext = altNext;
                }
                else if (i == maxCup.Value)
                {
                    QuadLinkedListNode<int> altPrev = qlCupsStart.Find(i - 1);
                   // QuadLinkedListNode<int> altNext = qlCupsStart.Find(minCup);

                    current.AltPrev = altPrev;
                    //current.AltNext = altNext;
                }
                else
                {                    
                    QuadLinkedListNode<int> altPrev = qlCupsStart.Find(i - 1);
                    QuadLinkedListNode<int> altNext = qlCupsStart.Find(i + 1);

                    current.AltPrev = altPrev;
                    current.AltNext = altNext;
                }
            }            

            //add the extra cups up to the maximum # of cups, also setting up the alternate links
            for (int i = maxCup.Value + 1; i <= numCups; i++)
            {
                QuadLinkedListNode<int> newNode = new QuadLinkedListNode<int>(i);

                maxNode.AltNext = newNode;
                newNode.AltPrev = maxNode;

                qlCupsCurrent = qlCupsCurrent.Add(newNode);
                maxNode = qlCupsCurrent;
            }

            //Link the first and last nodes making it a circular list
            qlCupsStart.Prev = qlCupsCurrent;
            qlCupsCurrent.Next = qlCupsStart;

            //link the first and last alternate links making them circular too
            qlCup1.AltPrev = qlCupsCurrent;
            qlCupsCurrent.AltNext = qlCup1;

            //int currentIndex = 0;
            ////int iterations = 10000000;
            int currentIteration = 0;

            //int min = llCups.Min();
            ////int min = cupsByCup.Min(x => x.Key);
            //int max = llCups.Max();
            ////int max = cupsByCup.Max(x => x.Key);

            //int cupCount = llCups.Count();
            ////int cupCount = cupsByCup.Count();

            //LinkedListNode<int> currentValue = llCups.First;
            ////int currentValue = cupsByPosition[1];
            ///
            qlCupsCurrent = qlCupsStart;

            List<string> output = new List<string>();
            //output.Add("New Execution Beginning");
            //output.Add(DateTime.Now.ToString());
            //output.Add(QuadLinkedToString(qlCupsCurrent));
            //WriteToFile("debugging.csv", output);

            while (currentIteration < numIterations)
            {
                //int currentValue = cups[currentIndex];

                //remove the 3 cups after the current cup, save their location
                QuadLinkedListNode<int> removedNodes = qlCupsCurrent.Next;
                qlCupsCurrent.Next = qlCupsCurrent.Next.Next.Next.Next;
                qlCupsCurrent.Next.Prev = qlCupsCurrent;

                //List<QuadLinkedListNode<int>> next3Values = NextValues(ref qlCupsCurrent, 3);

                //LinkedListNode<int> next1 = dOfLLCups[1].Next;
                //LinkedListNode<int> next2 = next1.Next;
                //long testing = (long)next1.Value * (long)next2.Value;

                //foreach (QuadLinkedListNode<int> cup in next3Values)
                //{
                //    cup.n;
                //}

                //int cup1 = //cups[CircularIndex(cupCount, currentIndex + 1)];
                //int cup2 = cups[CircularIndex(cupCount, currentIndex + 2)];
                //int cup3 = cups[CircularIndex(cupCount, currentIndex + 3)];

                //cups.Remove(cup1);
                //cups.Remove(cup2);
                //cups.Remove(cup3);

                QuadLinkedListNode<int> qlDestination = DestinationCup(ref qlCupsCurrent, ref removedNodes);
                //LinkedListNode<int> destinationNode = DestinationCupIndex(ref llCups, ref dOfLLCups, currentValue, max);

                //re-insert the removed cups
                QuadLinkedListNode<int> qlCupAfterDestination = qlDestination.Next;
                qlDestination.Next = removedNodes;
                removedNodes.Next.Next.Next = qlCupAfterDestination;

                removedNodes.Prev = qlDestination;
                qlCupAfterDestination.Prev = removedNodes.Next.Next;


                //foreach (int cup in next3Values)
                //{
                //    LinkedListNode<int> newNode = llCups.AddAfter(destinationNode, cup);

                //    dOfLLCups[newNode.Value] = newNode;

                //    destinationNode = newNode;
                //}

                //InsertOrAdd(ref cups, destinationIndex + 1, cup1);
                //InsertOrAdd(ref cups, destinationIndex + 2, cup2);
                //InsertOrAdd(ref cups, destinationIndex + 3, cup3);

                //currentIndex = CircularIndex(cupCount, cups.IndexOf(currentValue) + 1);

                qlCupsCurrent = qlCupsCurrent.Next;
                //currentValue = NextNode(ref llCups, currentValue);

                

                currentIteration++;

                
            }

            //List<string> loutput = new List<string>();
            //loutput.Add(QuadLinkedToString(qlCupsStart));
            //WriteToFile("debugging.csv", loutput);

            //QuadLinkedListNode<int> qlCup1 = qlCupsStart.Find(1);
            long next1 = (long) qlCup1.Next.Value;
            long next2 = (long) qlCup1.Next.Next.Value;

            long result = next1 * next2;
            //long result = 0;
            return $"Result { result }.";
        }

        private LinkedListNode<int> NextNode(ref LinkedList<int> list, LinkedListNode<int> node)
        {
            if (node.Next == null)
                return list.First;
            else
                return node.Next;
        }

        private List<QuadLinkedListNode<int>> NextValues(ref QuadLinkedListNode<int> node, int numberOfValues)
        {
            List<QuadLinkedListNode<int>> values = new List<QuadLinkedListNode<int>>();

            //LinkedListNode<int> currentValue = list.Find(value);
            //LinkedListNode<int> nextValue;

            for (int i = 0; i < numberOfValues; i++)
            {
                if (node.Next != null)
                {
                    values.Add(node.Next);
                }

                node = node.Next;
            }

            return values;
        }

        private List<int> NextValues(ref Dictionary<int, int> dicByKey, ref Dictionary<int, int> dicByValue,  int currentNumber, int numberOfValues)
        {
            List<int> values = new List<int>();

            int currentPosition = dicByKey[currentNumber];

            for (int i = 0; i < numberOfValues; i++)
            {
                values.Add(dicByValue[currentPosition + i]);
            }

            return values;
        }


        private int CircularIndex(int numItems, int index)
        {
            return (index + numItems) % numItems;
        }

        private QuadLinkedListNode<int> DestinationCup(ref QuadLinkedListNode<int> currentCup, ref QuadLinkedListNode<int> removedCups)
        {
            QuadLinkedListNode<int> destination = currentCup.AltPrev;
            bool hasBeenRemoved = true;

            while (hasBeenRemoved)
            {
                hasBeenRemoved = false;

                QuadLinkedListNode<int> removedCupsToIterate = removedCups;

                for (int i = 0; i < 3; i++)
                {
                    if (removedCupsToIterate.Value == destination.Value)
                    {
                        hasBeenRemoved = true;
                        break;
                    }

                    removedCupsToIterate = removedCupsToIterate.Next;
                }

                if (hasBeenRemoved)
                {
                    destination = destination.AltPrev;
                }
            }

            return destination;
        }

        private LinkedListNode<int> DestinationCupIndex(ref LinkedList<int> cups, ref Dictionary<int, LinkedListNode<int>> dictionary ,LinkedListNode<int> node, int globalMax) //, int globalMin, int globalMax)
        {
            LinkedListNode<int> destinationNode = null; 

            for (int i = 1; i <= 3; i++)
            {
                //destinationNode = cups.Find(node.Value - i);
                destinationNode = dictionary[node.Value - i];

                if (destinationNode != null)
                    break;
            }

            if (destinationNode == null)
            {
                //destinationNode = cups.Find(cups.Max());
                destinationNode = dictionary[globalMax];
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

        private string QuadLinkedToString(QuadLinkedListNode<int> list)
        {
            int startValue = list.Value;

            StringBuilder sb = new StringBuilder();

            sb.Append(list.Value);
            sb.Append(",");

            list = list.Next;

            while (list.Value != startValue)
            {
                sb.Append(list.Value);
                sb.Append(",");

                list = list.Next;
            }

            //sb.Append(list.Next.Value);

            return sb.ToString();
        }

        private void WriteToFile (string filename, List<string> values)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename, true))
            {
                foreach (string line in values)
                    file.WriteLine(line);
            }

        }
    }
}
