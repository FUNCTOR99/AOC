using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay15Part2 : AOCProblem
    {
        public AOCDay15Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            List<IIngredient> ingredients = new List<IIngredient>();

            //get the input
            foreach (String line in input)
            {
                String ingredientName = StringOps.SubStringPre(line, ":");
                int capacity = Convert.ToInt32(StringOps.SubStringPostAndPre(line, "capacity", ", durability").Trim());
                int durability = Convert.ToInt32(StringOps.SubStringPostAndPre(line, "durability", ", flavor").Trim());
                int flavor = Convert.ToInt32(StringOps.SubStringPostAndPre(line, "flavor", ", texture").Trim());
                int texture = Convert.ToInt32(StringOps.SubStringPostAndPre(line, "texture", ", calories").Trim());
                int calories = Convert.ToInt32(StringOps.SubStringPost(line, "calories").Trim());

                ingredients.Add(Factory.CreateIngredient(ingredientName, capacity, durability, flavor, texture, calories));
            }

            List<int[]> ingredientPermutations = Combinations.CombinationsThatSumTo(new int[ingredients.Count()], 100);

            int maxScore = 0;

            foreach (int[] ingredientPermutation in ingredientPermutations)
            {
                ICookie cookie = Factory.CreateCookie(ingredients, ingredientPermutation);

                cookie.CalculateScore();

                if (cookie.TotalCalories == 500)
                {
                    if (cookie.Score >= maxScore)
                    {
                        maxScore = cookie.Score;
                    }
                }
            }

            return $"The Best Cookie that is 500 Calories has a score of {maxScore}!";

        }


      
    }
}
