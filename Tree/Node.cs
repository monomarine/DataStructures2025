using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
#pragma warning disable
    internal class Node
    {
        public string Value { get; set; } //полезные данные
        public Node Left { get; set; } //ссылка на левое поддерево
        public Node Right { get; set; } //ссылка на правое поддерево

        public Node(string value = null, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }
}
