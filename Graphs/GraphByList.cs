using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Graphs
{
	internal class GraphByList : IEnumerable<Node>
	{
		private Node root;
		private HashSet<Node> vector;

		public GraphByList(Student rootValue)
		{
			this.root = new Node(rootValue);
			vector = new();
		}

		public Node AddNode(Student value, Node? parent = null)
		{
			Node node = new Node(value);
			if (parent == null)
				root.Neighbors.Add(node);
			else
				parent.Neighbors.Add(node);
			return node;
		}

		public void RemoveNode(Node node)
		{
			if (node == null) return;

			root.Neighbors.Remove(node);
			foreach (Node child in root.Neighbors)
			{
				child.Neighbors.Remove(node);
			}
			node.Neighbors.Clear();
		}

		private void DepthRecursive(Node startNode)
		{
			if (startNode == null || vector.Contains(startNode)) return;
			vector.Add(startNode);
			Console.WriteLine($"Студент: {startNode.Value.FullName} Количество баллов: {startNode.Value.AverageScore}");
			foreach (Node node in startNode.Neighbors)
			{
				DepthRecursive(node);
			}
		}

		public void Depth(Node? startNode = null)
		{
			vector = new HashSet<Node>();
			DepthRecursive(startNode ?? root);
		}

		public void Width(Node? node = null)
		{
			Queue<Node> queue = new Queue<Node>();
			vector = new HashSet<Node>();

			Node start = node ?? root;
			queue.Enqueue(start);
			vector.Add(start);

			while (queue.Count > 0)
			{
				Node current = queue.Dequeue();
				Console.WriteLine($"Студент: {current.Value.FullName} Количество баллов: {current.Value.AverageScore}");
				foreach (Node child in current.Neighbors)
				{
					if (!vector.Contains(child))
					{
						vector.Add(child);
						queue.Enqueue(child);
					}
				}
			}
		}

		/// <summary>
		/// Возвращает общее количество баллов у всех студентов в графе
		/// </summary>
		public float ReceiveFullScore()
		{
			float fullScore = 0;

			IEnumerator<Node> nodeEnumerator = GetEnumerator();

			while (nodeEnumerator.MoveNext())
			{
				fullScore += nodeEnumerator.Current.Value.AverageScore;
			}

			return fullScore;
		}

		/// <summary>
		/// Возвращает среднее количество баллов у студентов в графе
		/// </summary>
		public float ReceiveAverageScore()
		{
			float fullScore = 0;
			int iterations = 0;

			IEnumerator<Node> nodeEnumerator = GetEnumerator();

			while (nodeEnumerator.MoveNext())
			{
				fullScore += nodeEnumerator.Current.Value.AverageScore;
				iterations++;
			}

			return fullScore / iterations;
		}


		/// <summary>
		/// Возвращает узел с самым большим количеством соединений (самый общительный студент)
		/// </summary>
		public Node FindNodeWithMostMembers()
		{
			Node maxNode = root;

			IEnumerator<Node> nodeEnumerator = GetEnumerator();

			while (nodeEnumerator.MoveNext())
			{
				Node currentNode = nodeEnumerator.Current;
				if (currentNode.Neighbors.Count > maxNode.Neighbors.Count)
					maxNode = currentNode;
			}

			return maxNode;
		}

		public void AddEdge(Node n1, Node n2 = null) 
		{
			if (n1 == null && n2 == null) return;

			n2 = n2 ?? root;

			if (!n1.Neighbors.Contains(n2))
				n1.Neighbors.Add(n2);
			if (!n2.Neighbors.Contains(n1))
				n2.Neighbors.Add(n1);
		}

		public void RemoveEdge(Node n1, Node n2)
		{
			if (n1 == null || n2 == null) return;

			if (n1.Neighbors.Contains(n2))
				n1.Neighbors.Remove(n2);
			if (n2.Neighbors.Contains(n1))
				n2.Neighbors.Remove(n1);
		}

		public bool Contains(Student value, Node? startNode = null)
		{
			if (value == null) return false;

			vector = new();

			return FindNodeRecursive(value, startNode ?? root) != null;
		}

		public Node FindNode(Student findValue, Node? startNode = null)
		{
			vector = new(); 
			return FindNodeRecursive(findValue, startNode ?? root);
		}	

		private Node FindNodeRecursive(Student findValue, Node startNode)
		{
			if (startNode == null || vector.Contains(startNode)) return null;

			vector.Add(startNode);
			if (startNode.Value == findValue) 
				return startNode;

			foreach (Node child in startNode.Neighbors)
			{
				Node findNode = FindNodeRecursive(findValue, child);
				if (findNode != null) return findNode;
			}
			return null;
		}

		public IEnumerator<Node> GetEnumerator()
		{
			Queue<Node> queue = new Queue<Node>();
			vector = new HashSet<Node>();

			Node start = root;
			queue.Enqueue(start);
			vector.Add(start);
			yield return start;

			while (queue.Count > 0)
			{
				Node current = queue.Dequeue();
				foreach (Node child in current.Neighbors)
				{
					if (!vector.Contains(child))
					{
						vector.Add(child);
						queue.Enqueue(child);
						yield return child;
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
