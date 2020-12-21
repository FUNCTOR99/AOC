using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day21Part1 : AOCProblem
    {
        public AOC2020Day21Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<Food> foods = new List<Food>();

            List<string> allergens = new List<string>();
            List<string> ingredients = new List<string>();

            Dictionary<string, string> ingredientAllergenMap = new Dictionary<string, string>();


            foreach (String line in input)
            {
                Food food = new Food(line);
                foods.Add(food);

                foreach (string allergen in food.Allergens)
                {
                    if (allergens.Contains(allergen) == false)
                    {
                        allergens.Add(allergen);
                    }
                }

                foreach (string ingredient in food.Ingredients)
                {
                    if (ingredients.Contains(ingredient) == false)
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }

            bool moreIterationsNeeded = true;
            int minIngredients = int.MaxValue;

            while (moreIterationsNeeded)
            {
                moreIterationsNeeded = false;

                foreach (string allergen in allergens)
                {
                    List<Food> foodWithAllergen = foods.Where(fd => fd.Allergens.Contains(allergen)).ToList();
                    List<string> allergenIngredients = foodWithAllergen[0].Ingredients;

                    if (foodWithAllergen.Count() > 1)
                    {
                        for (int i = 0; i < foodWithAllergen.Count() - 1; i++)
                        {
                            allergenIngredients = allergenIngredients.Intersect(foodWithAllergen[i].Ingredients.Intersect(foodWithAllergen[i + 1].Ingredients).ToList()).ToList();
                        }
                    }

                    allergenIngredients = allergenIngredients.Intersect(ingredients).ToList();

                    if (allergenIngredients.Count() > 1)
                    {
                        //string uhoh;
                        moreIterationsNeeded = true;

                        if (allergenIngredients.Count() < minIngredients)
                            minIngredients = allergenIngredients.Count();
                    }
                    else if (allergenIngredients.Count() == 1)
                    {
                        ingredients.Remove(allergenIngredients[0]);
                        ingredientAllergenMap.Add(allergen, allergenIngredients[0]);
                    }
                }
            }

            int count = 0;

            foreach (string ingredient in ingredients)
            {
                foreach (Food food in foods)
                {
                    if (food.Ingredients.Contains(ingredient))
                        count++;
                }
            }


            return $"Result { count }.";
        }


    }
}
