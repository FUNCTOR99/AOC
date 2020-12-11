using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AdapterTree : IAdapterTree
    {
        public INode Tree { get; set; }

        public long LeafCount { get; set; }

        public AdapterTree(int[] values)
        {
            Tree = Factory.CreateNode(values[0]);

            BuildTree(Tree, ref values);

            LeafCount = CountLeaves(Tree);
        }

        private void BuildTree(INode tree, ref int[] values)
        {
            foreach (int value in values)
            {
                if ((value - tree.Value <= 3) && (value - tree.Value >= 1))
                {
                    INode newNode = Factory.CreateNode(value);

                    BuildTree(newNode, ref values);

                    tree.Nodes.Add(newNode);
                }
            }
        }

        private int CountLeaves(INode tree)
        {
            if (tree.Nodes.Count() == 0)
            {
                return 1;
            }
            else
            {
                int leafCount = 0;

                foreach (INode node in tree.Nodes)
                {
                    leafCount = leafCount + CountLeaves(node);
                }

                return leafCount;
            }
        }


    }
}
