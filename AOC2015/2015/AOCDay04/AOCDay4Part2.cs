using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay04Part2 : AOCProblem
    {

        public AOCDay04Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            Int64 seed = 0;
            bool hashMatches = false;

            String testString = null;
            String md5Hash = null;


            while (hashMatches == false)
            {
                testString = $"{input[0]}{seed.ToString()}";
                md5Hash = MD5.CalculateMD5(testString);

                if (md5Hash.StartsWith("000000"))
                {
                    hashMatches = true;
                }
                else
                {
                    seed++;
                }
            }

            return $"Number: {seed}   Produces a hash:  { md5Hash }";
        }

        
    }
}
