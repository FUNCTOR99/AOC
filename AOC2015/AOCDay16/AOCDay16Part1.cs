using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay16Part1 : AOCProblem
    {
        public AOCDay16Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            List<IAuntSue> auntSues = new List<IAuntSue>();

            //get the input
            foreach (String line in input)
            {
                auntSues.Add(Factory.CreateAuntSue(line));
            }

            //check all aunt Sues if they match the readings

            IAuntSue giftingAuntSue = Factory.CreateAuntSue("Sue -1: children: 3, cats: 7, samoyeds: 2, pomeranians: 3, akitas: 0, vizslas: 0, goldfish: 5, trees: 3, cars: 2, perfumes: 1");

            foreach (IAuntSue auntSue in auntSues)
            {
                int matchingParameters = auntSue.MatchingParameterCount(giftingAuntSue);

                if (matchingParameters >= 3)
                {
                    giftingAuntSue = auntSue;
                    break;
                }

            }

            return $"Aunt Sue #{giftingAuntSue.AuntSueNumber} got me the gift.";            
        }  
        
        
      
    }
}
