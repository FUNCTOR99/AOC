using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day06Part2 : AOCProblem
    {

        public AOC2020Day06Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int sum = 0;
            string working = "";
            bool newGroup = true;

            foreach (String line in input)
            {
                if (line.Length != 0)
                {
                    if (newGroup)
                    {
                        working = line;
                        newGroup = false;
                    }
                    else
                    {
                        foreach (char x in working)
                        {
                            if (!line.Contains(x))
                            {
                                working = working.Replace(x.ToString(), "");
                            }
                        }
                    }                    
                }
                else
                {
                    sum = sum + working.Length;

                    newGroup = true;
                    working = "";
                }
            }

            sum = sum + working.Length;

            return $"Result { sum }.";
        }

        
    }
}
