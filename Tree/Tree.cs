using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Tree
    {
        public Node Root { get;  set; } //корень дерева
        public Tree()
        {
            Root = null;
        }

        public Node CreateBalancedTree(int nodeCount)
        {
            string text;
            Node root;
            if (nodeCount == 0) //базовый случай для остановки рекурсии
                root = null;
            else
            {
                Console.WriteLine("введите значения узла");
                text = Console.ReadLine();
                root = new Node(text);
                root.Left = CreateBalancedTree(nodeCount /  2);
                root.Right = CreateBalancedTree(nodeCount - nodeCount / 2 - 1); ;
            }

            return root;
        }

    }
}
