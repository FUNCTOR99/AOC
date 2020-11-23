namespace AOC2015
{
    public interface IIngredient
    {
        int Calories { get; set; }
        int Capacity { get; set; }
        int Durability { get; set; }
        int Flavor { get; set; }
        string Name { get; set; }
        int Texture { get; set; }
    }
}