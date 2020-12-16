using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day15Part2 : AOCProblem
    {

        public AOC2020Day15Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<long> history = new List<long>();

            foreach (String line in input)
            {
                string[] inputs = line.Split(',');

                foreach (string value in inputs)
                {
                    history.Add(Convert.ToInt64(value));
                }
            }

            int nextIndex = history.Count();
            //long turnsApart = 0;
            int runUntil = 30000000; //2020;

            Dictionary<long, int[]> historyDic = new Dictionary<long, int[]>();
            // value[0] == last index added
            // value[1] == previous index added

            int currentIteration = 0;

            foreach (long number in history)
            {
                historyDic.Add(number, new int[] { currentIteration, -1});
                currentIteration++;
            }

            long lastNumber = historyDic.Last().Key;

            while (currentIteration < runUntil)
            {
                if (historyDic.ContainsKey(lastNumber))
                {
                    if (historyDic[lastNumber][1] == -1)    //first time this number was spoken
                    {
                        lastNumber = 0;

                        historyDic[lastNumber] = new int[] { currentIteration, historyDic[lastNumber][0] };
                    }
                    else
                    {
                        lastNumber = historyDic[lastNumber][0] - historyDic[lastNumber][1];

                        if (historyDic.ContainsKey(lastNumber))
                        {
                            historyDic[lastNumber] = new int[] { currentIteration, historyDic[lastNumber][0] };
                        }
                        else
                        {
                            historyDic.Add(lastNumber, new int[] { currentIteration, -1 });
                        }
                    }
                }
                else
                {   //Never gets executed as the number should be added in the previous iteration
                    if (historyDic.ContainsKey(0))
                    {
                        historyDic[0] = new int[] { currentIteration, historyDic[0][0] };
                    }
                    else
                    {
                        historyDic.Add(0, new int[] { currentIteration, -1 });
                    }

                    lastNumber = 0;
                }

                currentIteration++;
            }

            //brute force - was going to take 2.5 days

            //long[] historyArray = new long[runUntil];
            ////for (int j = 0; j < historyArray.Count(); j++)
            ////{
            ////    historyArray[j] = -1;
            ////}

            //int currentIndex = 0;

            //for (int i = 0; i < history.Count(); i++)
            //{
            //    historyArray[i] = history[i];
            //}

            //currentIndex = history.Count();


            //while (currentIndex < runUntil)
            //{
            //    turnsApart = TurnsApart(ref historyArray, currentIndex);

            //    if (turnsApart == -1)
            //    {
            //        historyArray[currentIndex] = 0;
            //    }
            //    else
            //    {
            //        historyArray[currentIndex] = turnsApart;
            //    }

            //    currentIndex++;
            //}

            return $"Result { lastNumber }.";

        }

        //private long TurnsApart(ref long[] history, int currentIndex)
        //{
        //    long turnsApart = -1;

        //    for (int i = currentIndex - 2; i >= 0; i--)
        //    {
        //        if (history[i] == history[currentIndex - 1])
        //        {
        //            turnsApart = currentIndex - 1 - i;
        //            break;
        //        }
        //    }

        //    return turnsApart;
        //}
    }
}
