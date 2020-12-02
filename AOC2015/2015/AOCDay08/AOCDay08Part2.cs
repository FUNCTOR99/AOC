using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public class AOCDay08Part2 : AOCProblem
    {
        public AOCDay08Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            Int32 stringLiteralCount = 0;

            foreach (String line in input)
            {
                stringLiteralCount = stringLiteralCount + Literals.NetLiteralCountInverse(line);
                
            }


            return $"The String Literal Count is { stringLiteralCount }.";
        }

      
    }
}
