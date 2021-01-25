using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class QuadLinkedListNode<T>
    {
        public T Value { get; set; }

        public QuadLinkedListNode<T> Next { get; set; }
        public QuadLinkedListNode<T> Prev { get; set; }

        public QuadLinkedListNode<T> AltNext { get; set; }
        public QuadLinkedListNode<T> AltPrev { get; set; }

        public QuadLinkedListNode(T value)
        {
            Value = value;
        }

        public void Remove()
        {
            Prev.Next = Next;

            Prev = null;
            Next = null;
        }

        public QuadLinkedListNode<T> Find (T value)
        {
            if (Value.Equals(value))
            {
                return this;
            }
            else
            {
                return Next.Find(value);
            }
        }

        public QuadLinkedListNode<T> Add(QuadLinkedListNode<T> node)
        {
            Next = node;
            node.Prev = this;

            return node;
        }
    }
}
