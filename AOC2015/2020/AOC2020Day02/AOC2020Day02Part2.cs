using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day02Part2 : AOCProblem
    {

        public AOC2020Day02Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {

            int validCount = 0;

            foreach (String line in input)
            {
                String policy = StringOps.SubStringPre(line, ":").Trim();
                char repeatChar = policy[policy.Length - 1];

                String working = policy.Replace(repeatChar.ToString(), "").Trim();

                String min = StringOps.SubStringPre(line, "-");

                working = working.Remove(0, working.IndexOf("-")).Trim();
                working = working.Replace("-", "").Trim();


                String max = working; //StringOps.SubStringPostAndPre(line, repeatChar.ToString(), "-");

                String pwd = StringOps.SubStringPost(line, ":").Trim();

                int charCount = 0;

                if ((pwd[Convert.ToInt32(min) - 1] == repeatChar) ^ (pwd[Convert.ToInt32(max) - 1] == repeatChar))
                {
                    validCount++;
                }               

            }



            return $"Santa is on floor { validCount }.";
        }

        
    }
}
