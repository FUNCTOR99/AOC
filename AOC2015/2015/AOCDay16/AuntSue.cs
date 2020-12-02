using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AuntSue : IAuntSue
    {
        public int AuntSueNumber { get; set; }
        public int Children { get; set; }
        public int Cats { get; set; }
        public int Samoyeds { get; set; }
        public int Pomeranians { get; set; }
        public int Akitas { get; set; }
        public int Vizslas { get; set; }
        public int Goldfish { get; set; }
        public int Trees { get; set; }
        public int Cars { get; set; }
        public int Perfumes { get; set; }

        public AuntSue(String inputParameters)
        {
            ParseInput(inputParameters);
        }

        private void ParseInput(String input)
        {
            input = input.Trim() + ",";

            AuntSueNumber = Convert.ToInt32(StringOps.ParameterAfter(input, "Sue", ":").Trim());

            if (input.Contains("children"))
                Children = Convert.ToInt32(StringOps.ParameterAfter(input, "children:", ",").Trim());
            else
                Children = -1;

            if (input.Contains("cats"))
                Cats = Convert.ToInt32(StringOps.ParameterAfter(input, "cats:", ",").Trim());
            else
                Cats = -1;

            if (input.Contains("samoyeds"))
                Samoyeds = Convert.ToInt32(StringOps.ParameterAfter(input, "samoyeds:", ",").Trim());
            else
                Samoyeds = -1;

            if (input.Contains("pomeranians"))
                Pomeranians = Convert.ToInt32(StringOps.ParameterAfter(input, "pomeranians:", ",").Trim());
            else
                Pomeranians = -1;

            if (input.Contains("akitas"))
                Akitas = Convert.ToInt32(StringOps.ParameterAfter(input, "akitas:", ",").Trim());
            else
                Akitas = -1;

            if (input.Contains("vizslas"))
                Vizslas = Convert.ToInt32(StringOps.ParameterAfter(input, "vizslas:", ",").Trim());
            else
                Vizslas = -1;

            if (input.Contains("goldfish"))
                Goldfish = Convert.ToInt32(StringOps.ParameterAfter(input, "goldfish:", ",").Trim());
            else
                Goldfish = -1;

            if (input.Contains("trees"))
                Trees = Convert.ToInt32(StringOps.ParameterAfter(input, "trees:", ",").Trim());
            else
                Trees = -1;

            if (input.Contains("cars"))
                Cars = Convert.ToInt32(StringOps.ParameterAfter(input, "cars:", ",").Trim());
            else
                Cars = -1;

            if (input.Contains("perfumes"))
                Perfumes = Convert.ToInt32(StringOps.ParameterAfter(input, "perfumes:", ",").Trim());
            else
                Perfumes = -1;
        }

        public int MatchingParameterCount(IAuntSue sue)
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
                if (Cats == sue.Cats)
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
                if (Pomeranians == sue.Pomeranians)
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
                if (Goldfish == sue.Goldfish)
                {
                    matchFound++;
                }
            }

            if (Trees != -1)
            {
                if (Trees == sue.Trees)
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
