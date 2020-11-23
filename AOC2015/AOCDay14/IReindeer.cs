namespace AOC2015
{
    public interface IReindeer
    {
        int FlySpeed { get; set; }
        int FlyDuration { get; set; }

        string Name { get; set; }
        int RestDuration { get; set; }
    }
}