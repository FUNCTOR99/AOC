using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Node : INode
    {
        public int Value { get; set; }

        public List<INode> Nodes { get; set; }

        public Node(int value)
        {
            Value = value;
            Nodes = new List<INode>();
        }
    }
}
