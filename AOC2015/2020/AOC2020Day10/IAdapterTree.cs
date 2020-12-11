namespace AOC2015
{
    public interface IAdapterTree
    {
        long LeafCount { get; set; }
        INode Tree { get; set; }
    }
}