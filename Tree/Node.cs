using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
	internal class Node
	{
		public User Value { get; set; }
		public Node Left { get; set; } //ссылка на левое поддерево 
		public Node Right { get; set; } //ссылка на право поддерево

		public Node(User value = null, Node left = null, Node right = null)
		{
			this.Value = value;
			this.Left = left;
			this.Right = right;
		}
	}
}
