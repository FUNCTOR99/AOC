using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay11Part1 : AOCProblem
    {
        public AOCDay11Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            String nextPwd = "";

            //read the input
            foreach (String line in input)
            {
                IPasswordFinder password = Factory.CreatePasswordFinder(line);

                nextPwd = password.FindNext();

                //Console.WriteLine($"Seed: {line}    Next Password: {password.FindNext()}");
            }            

            return $"Next Password is {nextPwd}.";            
        }

        
      
    }
}
