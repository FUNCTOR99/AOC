using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Food
    {
        public List<string> Ingredients { get; set; }

        public List<string> Allergens { get; set; }

        public Food(string input)
        {
            Initialize(input);
        }

        private void Initialize(string input)
        {
            string allergens = StringOps.SubStringPost(input, "(").Replace(")", "").Trim().Replace("contains", "").Trim();
            Allergens = allergens.Split(", ").ToList();

            string ingredients = StringOps.SubStringPre(input, "(").Trim();
            Ingredients = ingredients.Split(" ").ToList();
        }
    }
}
