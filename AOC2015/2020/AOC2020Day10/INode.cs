using System.Collections.Generic;

namespace AOC2015
{
    public interface INode
    {
        List<INode> Nodes { get; set; }
        int Value { get; set; }
    }
}