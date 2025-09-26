using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
	internal class Tree
	{
		public Node Root { get; set; }
		
		public Tree()
		{
			Root = null;
		}

		public Node CreateBalancedTree(int nodeCount)
		{
			string text;
			DateTime birthDate = new DateTime(2000,1,1);
			Node root;
		
			if (nodeCount == 0) 
				root = null;
			else
			{
				Console.WriteLine("Введите ФИО для пользователя");
				text = Console.ReadLine();
				Console.WriteLine("Введите дату рождения пользователя");
				DateTime.TryParse(Console.ReadLine(), out birthDate);
				root = new Node(new User(text, birthDate));
				root.Left = CreateBalancedTree(nodeCount / 2);
				root.Right = CreateBalancedTree(nodeCount - nodeCount / 2 - 1);
			}
			return root;
		}

		private Node AddNodeRecursive(Node node, User value)
		{
			if (node == null)
				return new Node(value);
			if (value.Age < node.Value.Age)
				node.Left = AddNodeRecursive(node.Left,value);
			else if (value.Age > node.Value.Age)
				node.Right = AddNodeRecursive(node.Right, value);
			return node;
		}

		public void AddNode(User value) =>
			Root = AddNodeRecursive(Root, value);

		private void TreeTraversalRecursive(Node node,List<User> results)
		{
			if (node == null) return;

			results.Add(node.Value);
			TreeTraversalRecursive(node.Left, results);
			TreeTraversalRecursive(node.Right, results);
		}

		public List<User> TreeTraversal()
		{
			List<User> results = new();
			TreeTraversalRecursive(Root, results);
			return results;
		}

		public float AverageAge()
		{
			List<User> results = TreeTraversal();
			float fullValue = 0;
			foreach (var item in results)
			{
				fullValue += item.Age;
			}
			return fullValue / results.Count;
		}

		private bool FindNodeRecursive(Node node, User value)
		{
			if (node == null) return false;
			if (node.Value.Age == value.Age)
				return true;
			else if (value.Age < node.Value.Age)
				return FindNodeRecursive(node.Left, value);
			else
				return FindNodeRecursive(node.Right, value);
		}

		private Node DeleteNodeRecursive(Node node, User value)
		{
			if (node == null) return null;
			if (value.Age < node.Value.Age)
				node.Left = DeleteNodeRecursive(node.Left, value);
			else if (value.Age > node.Value.Age)
				node.Right = DeleteNodeRecursive(node.Right, value);
			else
			{
				if (node.Left == null)
					return node.Right;
				else if (node.Right == null)
					return node.Left;

				node.Value = FindMinValue(node.Right);
				node.Right = DeleteNodeRecursive(node.Right, node.Value);
			}
			return node;
		}

		public void DeleteNode(User value) =>
			DeleteNodeRecursive(Root, value);

		private User FindMinValue(Node node)
		{
			User minValue = node.Value;
			while (node.Left != null)
			{
				minValue = node.Left.Value;
				node = node.Left;
			}
			return minValue;
		}

		public bool FindNode(User value) =>
			FindNodeRecursive(Root, value);
	}