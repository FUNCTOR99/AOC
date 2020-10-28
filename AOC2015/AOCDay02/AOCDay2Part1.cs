using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay2Part1 : IAOCProblem
    {
        public AOCDay2Part1(String[] input, IStandardMessages standardMessages): base(input, standardMessages) { }

        protected override string doSolve()
        {
            int wrappingPaperRequired = 0;

            foreach (String line in _input)
            {
                string[] dimensions = line.Split('x');

                if (dimensions.Length == 3)
                {
                    IPresent present = Factory.CreatePresent(Convert.ToInt32(dimensions[0].Trim()), Convert.ToInt32(dimensions[1].Trim()), Convert.ToInt32(dimensions[2].Trim()));

                    wrappingPaperRequired = wrappingPaperRequired + present.TotalSurfaceArea() + present.AreaSmallestSide();
                }
                else
                {
                    throw new Exception($"Present doesn't have 3 dimensions: { line }");
                }
                
            }

            return $"The Elves should order { wrappingPaperRequired } square feet of wrapping paper.";
            
        }
    }
}
