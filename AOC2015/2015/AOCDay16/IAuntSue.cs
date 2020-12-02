namespace AOC2015
{
    public interface IAuntSue
    {
        int Akitas { get; set; }
        int AuntSueNumber { get; set; }
        int Cars { get; set; }
        int Cats { get; set; }
        int Children { get; set; }
        int Goldfish { get; set; }
        int Perfumes { get; set; }
        int Pomeranians { get; set; }
        int Samoyeds { get; set; }
        int Trees { get; set; }
        int Vizslas { get; set; }

        int MatchingParameterCount(IAuntSue sue);
    }
}