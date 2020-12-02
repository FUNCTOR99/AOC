using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay09Part2 : AOCProblem
    {
        public AOCDay09Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            List<IPath<String>> paths = new List<IPath<String>>();

            //read the input
            foreach (String line in input)
            {
                Int32 distance = Convert.ToInt32(StringOps.SubStringPost(line, "=").Trim());

                String ends = StringOps.SubStringPre(line, "=").Trim();

                IPath<String> path = Factory.CreatePath(StringOps.SubStringPre(ends, "to").Trim(), StringOps.SubStringPost(ends, "to").Trim(), distance);
                paths.Add(path);
            }

            IPathCollection pathCollection = Factory.CreatePathCollection(paths);

            Int32 longestPath = pathCollection.LongestDistance();

            return $"The Shortest Route is { longestPath }.";

        }

      
    }
}
