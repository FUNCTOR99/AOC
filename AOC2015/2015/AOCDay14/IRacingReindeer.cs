namespace AOC2015
{
    public interface IRacingReindeer
    {
        int DistanceTravelled { get; set; }
        IReindeer Reindeer { get; set; }

        void Race1Second();
    }
}