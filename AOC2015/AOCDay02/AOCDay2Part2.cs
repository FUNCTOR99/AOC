using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay2Part2 : AOCProblem
    {

        public AOCDay2Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }


        protected override String DoSolve(String[] input)
        {
            int ribbonRequired = 0;

            foreach (String line in input)
            {
                string[] dimensions = line.Split('x');

                if (dimensions.Length == 3)
                {
                    IPresent present = Factory.CreatePresent(Convert.ToInt32(dimensions[0].Trim()), Convert.ToInt32(dimensions[1].Trim()), Convert.ToInt32(dimensions[2].Trim()));

                    ribbonRequired = ribbonRequired + present.PerimeterSmallestSide() + present.Volume();
                }
                else
                {
                    throw new Exception($"Present doesn't have 3 dimensions: { line }");
                }
                
            }

            return $"The Elves should order { ribbonRequired } feet of ribbon.";
            
        }
    }
}
