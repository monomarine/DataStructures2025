using System;

namespace Tree
{
    internal class Node
    {
        public Person Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Person value, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
