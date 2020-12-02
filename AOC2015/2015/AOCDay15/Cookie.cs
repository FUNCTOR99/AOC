using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Cookie : ICookie
    {
        public List<IIngredient> Ingredients { get; set; }
        public int[] IngredientQuantities { get; set; }

        public int Score { get; set; }

        public int TotalCalories { get; set; }

        public Cookie(List<IIngredient> ingredients, int[] ingredientQuantities)
        {
            Ingredients = ingredients;
            IngredientQuantities = (int[])ingredientQuantities.Clone();
        }

        public int CalculateScore()
        {
            Score = 0;

            int capacity = 0;
            int durability = 0;
            int flavor = 0;
            int texture = 0;
            int calories = 0;

            for (int i = 0; i < Ingredients.Count(); i++)
            {
                capacity = capacity + (IngredientQuantities[i] * Ingredients[i].Capacity);
                durability = durability + (IngredientQuantities[i] * Ingredients[i].Durability);
                flavor = flavor + (IngredientQuantities[i] * Ingredients[i].Flavor);
                texture = texture + (IngredientQuantities[i] * Ingredients[i].Texture);
                calories = calories + (IngredientQuantities[i] * Ingredients[i].Calories);
            }

            if (capacity < 0)
                capacity = 0;

            if (durability < 0)
                durability = 0;

            if (flavor < 0)
                flavor = 0;

            if (texture < 0)
                texture = 0;

            if (calories < 0)
                calories = 0;

            Score = capacity * durability * flavor * texture;
            TotalCalories = calories;

            return Score;
        }
    }
}
