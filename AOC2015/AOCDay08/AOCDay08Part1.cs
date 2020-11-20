using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public class AOCDay08Part1 : AOCProblem
    {
        public AOCDay08Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            Int32 stringLiteralCount = 0;


            foreach (String line in input)
            {
                stringLiteralCount = stringLiteralCount + Literals.NetLiteralCount(line);                
            }           

            return $"The String Literal Count is { stringLiteralCount }.";
            
        }

        
      
    }
}
