using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
#pragma warning disable

	internal class Node<T> //узел списка
	{
		public T Data { get; set; }
		public Node<T> Next { get; set; }

		public Node(T data)
		{
			Data = data;
			Next = null;
		}
	}
}
