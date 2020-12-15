using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day14Part2 : AOCProblem
    {

        public AOC2020Day14Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int result = 0;

            long busID = Convert.ToInt64(input[0]);
            string[] busSched = input[1].Split(',');

            Dictionary<long, long> busOffsets = new Dictionary<long, long>();

            for (long i = 0; i < busSched.Count(); i++)
            {
                if (busSched[i].Equals("x") == false)
                {
                    busOffsets.Add(Convert.ToInt32(busSched[i]), i);
                }
            }

            bool matchFound = false;

            KeyValuePair<long, long> maxBusOffset = new KeyValuePair<long, long>(0, 0);

            foreach (KeyValuePair<long, long> pair in busOffsets)
            {
                if (pair.Key > maxBusOffset.Key)
                {
                    maxBusOffset = pair;
                }
            }

            long nextTime = 0;
            long maxBusIteration = 0;

            List<long> startingOffsets = new List<long>();

            foreach (KeyValuePair<long, long> pair in busOffsets)
            {
                startingOffsets.Add(CalculateStartingOffset((long)0, pair.Value, pair.Key));
            }

            long offset = CalculateCurrentOffset((long)1068781, (long)0, (long)7);
            offset = CalculateCurrentOffset((long)1068781, (long)1, (long)13);
            offset = CalculateCurrentOffset((long)1068781, (long)4, (long)59);
            offset = CalculateCurrentOffset((long)1068781, (long)6, (long)31);
            offset = CalculateCurrentOffset((long)1068781, (long)7, (long)19);


            offset = CalculateCurrentOffset((long)0, (long)0, (long)7);
            offset = CalculateCurrentOffset((long)0, (long)1, (long)13);
            offset = CalculateCurrentOffset((long)0, (long)4, (long)59);
            offset = CalculateCurrentOffset((long)0, (long)6, (long)31);
            offset = CalculateCurrentOffset((long)0, (long)7, (long)19);

            offset = CalculateCurrentOffset((long)1872, (long)0, (long)7);
            offset = CalculateCurrentOffset((long)1872, (long)1, (long)13);
            offset = CalculateCurrentOffset((long)1872, (long)4, (long)59);
            offset = CalculateCurrentOffset((long)1872, (long)6, (long)31);
            offset = CalculateCurrentOffset((long)1872, (long)7, (long)19);




            maxBusIteration = (long)100000000000000 / maxBusOffset.Key; //100 trillion
            maxBusIteration = (long)342992472522651 / maxBusOffset.Key; //100 trillion
            //maxBusIteration = (long)0 / maxBusOffset.Key; //100 trillion


            List<Thread> threads = new List<Thread>();
            int threadCount = Environment.ProcessorCount * 2;

            
                //Task.Factory.StartNew(() => ThreadIterator(maxBusIteration, i, threadCount, maxBusOffset, busOffsets, startingOffsets));
            Thread t0 = new Thread(() => ThreadIterator(maxBusIteration, 0, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t0);

            Thread t1 = new Thread(() => ThreadIterator(maxBusIteration, 1, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t1);

            Thread t2 = new Thread(() => ThreadIterator(maxBusIteration, 2, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t2);

            Thread t3 = new Thread(() => ThreadIterator(maxBusIteration, 3, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t3);

            Thread t4 = new Thread(() => ThreadIterator(maxBusIteration, 4, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t4);

            Thread t5 = new Thread(() => ThreadIterator(maxBusIteration, 5, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t5);

            Thread t6 = new Thread(() => ThreadIterator(maxBusIteration, 6, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t6);

            Thread t7 = new Thread(() => ThreadIterator(maxBusIteration, 7, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t7);

            Thread t8 = new Thread(() => ThreadIterator(maxBusIteration, 8, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t8);

            Thread t9 = new Thread(() => ThreadIterator(maxBusIteration, 9, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t9);

            Thread t10 = new Thread(() => ThreadIterator(maxBusIteration, 10, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t10);

            Thread t11 = new Thread(() => ThreadIterator(maxBusIteration, 11, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t11);

            Thread t12 = new Thread(() => ThreadIterator(maxBusIteration, 12, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t12);

            Thread t13 = new Thread(() => ThreadIterator(maxBusIteration, 13, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t13);

            Thread t14 = new Thread(() => ThreadIterator(maxBusIteration, 14, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t14);

            Thread t15 = new Thread(() => ThreadIterator(maxBusIteration, 15, threadCount, maxBusOffset, busOffsets, startingOffsets));
            threads.Add(t15);



            foreach (Thread t in threads)
            {
                t.Start();
            }


            //while (matchFound == false)
            //{
            //    matchFound = true;

            //    nextTime = (maxBusOffset.Key * maxBusIteration) - maxBusOffset.Value;
            //    int i = 0;

            //    foreach (KeyValuePair<long, long> pair in busOffsets)
            //    { 
            //        long currentOffset = CalculateCurrentOffset(nextTime, pair.Value, pair.Key);    //nextTime - ((((nextTime - pair.Value) / pair.Key) * pair.Key) + pair.Value);

            //        if (currentOffset != startingOffsets[i])
            //        {
            //            matchFound = false;
            //            break;
            //        }

            //        i++;
            //    }

            //    if (maxBusIteration == 179)
            //    {
            //        int x = 1;
            //    }

            //    maxBusIteration++;
            //}



            return $"Result { nextTime }.";

        }

        private long CalculateCurrentOffset(long time, long offset, long bus)
        {
            return (((time - ((((time - offset) / bus) * bus) + offset)) + bus) + offset) % bus;
        }

        private long CalculateStartingOffset(long time, long offset, long bus)
        {
            return ((time - ((((time - offset) / bus) * bus) + offset)) + bus) % bus;
        }

        private void ThreadIterator(long maxBusIteration, int threadOffset, int threadCount, KeyValuePair<long, long> maxBusOffset, Dictionary<long, long> busOffsets, List<long> startingOffsets )
        {
            bool matchFound = false;
            long nextTime = 0;

            while (matchFound == false)
            {
                matchFound = true;

                //if (threadOffset == 15)
                //{
                //    int k = 0;
                //}

                nextTime = (maxBusOffset.Key * (maxBusIteration  + threadOffset)) - maxBusOffset.Value;
                int i = 0;

                foreach (KeyValuePair<long, long> pair in busOffsets)
                {
                    long currentOffset = CalculateCurrentOffset(nextTime, pair.Value, pair.Key);    //nextTime - ((((nextTime - pair.Value) / pair.Key) * pair.Key) + pair.Value);

                    if (currentOffset != startingOffsets[i])
                    {
                        matchFound = false;
                        break;
                    }

                    i++;
                }

                maxBusIteration = maxBusIteration + threadCount;
            }

            Console.WriteLine($"Answer {threadOffset}: {nextTime}");
            //Environment.Exit(0);
        }
    }
}
