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
            int result = 0;

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
            long turnsApart = 0;
            int runUntil = 30000000;

            long[] historyArray = new long[runUntil];
            //for (int j = 0; j < historyArray.Count(); j++)
            //{
            //    historyArray[j] = -1;
            //}

            int currentIndex = 0;

            for (int i = 0; i < history.Count(); i++)
            {
                historyArray[i] = history[i];
            }

            currentIndex = history.Count();


            while (currentIndex < runUntil)
            {
                turnsApart = TurnsApart(ref historyArray, currentIndex);

                if (turnsApart == -1)
                {
                    historyArray[currentIndex] = 0;
                }
                else
                {
                    historyArray[currentIndex] = turnsApart;
                }

                currentIndex++;
            }





            return $"Result { historyArray[runUntil - 1] }.";

        }

        private long TurnsApart(ref long[] history, int currentIndex)
        {
            long turnsApart = -1;

            for (int i = currentIndex - 2; i >= 0; i--)
            {
                if (history[i] == history[currentIndex - 1])
                {
                    turnsApart = currentIndex - 1 - i;
                    break;
                }
            }

            return turnsApart;
        }
    }
}
