namespace AOC2015
{
    public interface ITicketParameter
    {
        string Name { get; set; }
        int Range1Max { get; set; }
        int Range1Min { get; set; }
        int Range2Max { get; set; }
        int Range2Min { get; set; }

        bool IsValid(int value);
    }
}