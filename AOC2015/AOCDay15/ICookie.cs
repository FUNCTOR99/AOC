using System.Collections.Generic;

namespace AOC2015
{
    public interface ICookie
    {
        int[] IngredientQuantities { get; set; }
        List<IIngredient> Ingredients { get; set; }
        int Score { get; set; }

        int TotalCalories { get; set; }

        int CalculateScore();
    }
}