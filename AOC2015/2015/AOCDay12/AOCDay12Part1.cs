using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay12Part1 : AOCProblem
    {
        public AOCDay12Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            String working = "";
            Int32 sum = 0;

            //read the input
            foreach (String line in input)
            {
                working = line;

                working = working.Replace(",", " ");                
                working = working.Replace(":", " ");                
                working = working.Replace("[", " ");
                working = working.Replace("]", " ");
                working = working.Replace("(", " ");
                working = working.Replace(")", " ");
                working = working.Replace("{", " ");
                working = working.Replace("}", " ");
                working = working.Replace("\"", " ");

                string[] items = working.Split(' ');

                foreach (string item in items)
                {
                    Int32 number = 0;
                    Int32.TryParse(item.Trim(), out number);

                    sum = sum + number;
                }
            }            

            return $"The sum is {sum}.";            
        }

        
      
    }
}
