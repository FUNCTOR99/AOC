using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class RealAuntSue : AuntSue, IRealAuntSue
    {
        public RealAuntSue(String inputParameters) : base(inputParameters) { }

        public int RealMatchingParameters(IAuntSue sue)
        {
            int matchFound = 0;

            if (Children != -1)
            {
                if (Children == sue.Children)
                {
                    matchFound++;
                }
            }

            if (Cats != -1)
            {
                if (Cats > sue.Cats)
                {
                    matchFound++;
                }
            }

            if (Samoyeds != -1)
            {
                if (Samoyeds == sue.Samoyeds)
                {
                    matchFound++;
                }
            }

            if (Pomeranians != -1)
            {
                if (Pomeranians < sue.Pomeranians)
                {
                    matchFound++;
                }
            }

            if (Akitas != -1)
            {
                if (Akitas == sue.Akitas)
                {
                    matchFound++;
                }
            }

            if (Vizslas != -1)
            {
                if (Vizslas == sue.Vizslas)
                {
                    matchFound++;
                }
            }

            if (Goldfish != -1)
            {
                if (Goldfish < sue.Goldfish)
                {
                    matchFound++;
                }
            }

            if (Trees != -1)
            {
                if (Trees > sue.Trees)
                {
                    matchFound++;
                }
            }

            if (Cars != -1)
            {
                if (Cars == sue.Cars)
                {
                    matchFound++;
                }
            }

            if (Perfumes != -1)
            {
                if (Perfumes == sue.Perfumes)
                {
                    matchFound++;
                }
            }

            return matchFound;
        }
    }
}
