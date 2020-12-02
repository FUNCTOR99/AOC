namespace AOC2015
{
    public interface IRelationship
    {
        string AcquaintanceName { get; set; }
        int Happiness { get; set; }
        string SourceName { get; set; }
    }
}