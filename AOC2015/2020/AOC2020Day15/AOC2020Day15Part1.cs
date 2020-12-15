using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day15Part1 : AOCProblem
    {
        public AOC2020Day15Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

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

            while (history.Count() <= 2020)
            {
                turnsApart = TurnsApart(history);

                if (turnsApart == -1)
                {
                    history.Add(0);
                }
                else
                {
                    history.Add(turnsApart);
                }
            }

           



            return $"Result { history[2019] }.";            

        }

        private long TurnsApart(List<long> history)
        {
            long turnsApart = -1;

            for (int i = history.Count() - 2; i >= 0; i--)
            {
                if (history[i] == history[history.Count() - 1])
                {
                    turnsApart = history.Count() - 1 - i;
                    break;
                }
            }

            return turnsApart;
        }

        


    }
}
