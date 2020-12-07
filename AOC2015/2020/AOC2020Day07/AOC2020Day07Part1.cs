using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day07Part1 : AOCProblem
    {
        public AOC2020Day07Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {     
            List<Bags> bags = new List<Bags>();

            foreach (String line in input)
            {
                bags.Add(new Bags(line));
            }
            int canContainGoldCount = 0;

            foreach (Bags bag in bags)
            {
                if (CanContainGold(bag, ref bags))
                {
                    canContainGoldCount++;
                }
            }

            return $"Result { canContainGoldCount }.";            

        }

        private bool CanContainGold(Bags bag, ref List<Bags> bags)
        {
            bool foundShinyGold = false;

            foreach (KeyValuePair<string, int> x in bag.containBags)
            {
                if (x.Key.Equals("shiny gold"))
                {
                    return true;
                }
                else 
                {
                    Bags nextBag = bags.First(y => y.BagColor.Equals(x.Key));

                    if (CanContainGold(nextBag, ref bags))
                    {
                        foundShinyGold = true;
                    }
                }
            }

            return foundShinyGold;
        }
    }
}
