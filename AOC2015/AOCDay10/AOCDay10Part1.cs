using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay10Part1 : AOCProblem
    {
        public AOCDay10Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            String lookAndSay = "";
            String sinput = "";
            int maxIterations = 40;

            //read the input
            foreach (String line in input)
            {
                lookAndSay = line;
                sinput = line;

                for (int i = 0; i < maxIterations; i++)
                {
                    lookAndSay = LookAndSay.ConvertToLookAndSay(lookAndSay);
                }
            }            

            return $"After {maxIterations} iterations, the length of the result is {lookAndSay.Length}.";            
        }

        
      
    }
}
