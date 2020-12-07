using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day07Part2 : AOCProblem
    {

        public AOC2020Day07Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<Bags> bags = new List<Bags>();

            foreach (String line in input)
            {
                bags.Add(new Bags(line));
            }

            int bagCount = GetBagCount(bags.First(y => y.BagColor.Equals("shiny gold")), ref bags) - 1;

            return $"Result { bagCount }.";
        }

        private int GetBagCount(Bags bag, ref List<Bags> bags)
        {
            int bagsAtThisLevel = 1;

            foreach (KeyValuePair<string, int> x in bag.containBags)
            {
                Bags nextBag = bags.First(y => y.BagColor.Equals(x.Key));

                bagsAtThisLevel = bagsAtThisLevel + (x.Value * GetBagCount(nextBag, ref bags));                
            }

            return bagsAtThisLevel;
        }
        
    }
}
