using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day04Part2 : AOCProblem
    {

        public AOC2020Day04Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<string> batch = new List<string>();
            List<Passport> passports = new List<Passport>();

            foreach (String line in input)
            {

                if (line.Trim().Equals(""))
                {
                    passports.Add(new Passport(batch.ToArray()));

                    batch.Clear();
                }
                else
                {
                    batch.Add(line);
                }

            }

            passports.Add(new Passport(batch.ToArray()));


            int validCount = 0;

            foreach (Passport passport in passports)
            {
                if (passport.IsStrictValid)
                    validCount++;
            }



            return $"Count: { validCount }.";
        }

        
    }
}
