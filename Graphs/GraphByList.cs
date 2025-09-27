using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    internal class GraphByList
    {
        private Node root;
        private HashSet<Node> vector;

        public GraphByList(string rootValue) => root = new Node(rootValue);
        public GraphByList(Student rootStudent) => root = new Node(rootStudent);

        public Node AddNode(string value, Node parent = null)
        {
            Node newNode = new Node(value);
            AddConnection(newNode, parent);
            return newNode;
        }

        public Node AddNode(Student student, Node parent = null)
        {
            Node newNode = new Node(student);
            AddConnection(newNode, parent);
            return newNode;
        }

        private void AddConnection(Node newNode, Node parent)
        {
            if (parent == null)
            {
                newNode.Neighbors.Add(root);
                root.Neighbors.Add(newNode);
                newNode.Friends.Add(root);
                root.Friends.Add(newNode);
            }
            else
            {
                newNode.Neighbors.Add(parent);
                parent.Neighbors.Add(newNode);
                newNode.Friends.Add(parent);
                parent.Friends.Add(newNode);
            }
        }

        public void AddEdge(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return;
            if (n1 == null || n2 == null)
            {
                Node node = n1 ?? n2;
                node.Friends.Add(root);
                root.Friends.Add(node);
                return;
            }

            if (!n1.Neighbors.Contains(n2)) n1.Neighbors.Add(n2);
            if (!n2.Neighbors.Contains(n1)) n2.Neighbors.Add(n1);
            if (!n1.Friends.Contains(n2)) n1.Friends.Add(n2);
            if (!n2.Friends.Contains(n1)) n2.Friends.Add(n1);
        }

        public void RemoveEdge(Node n1, Node n2)
        {
            if (n1 == null || n2 == null) return;
            n1.Neighbors.Remove(n2);
            n2.Neighbors.Remove(n1);
            n1.Friends.Remove(n2);
            n2.Friends.Remove(n1);
        }

        public void RemoveNode(Node node)
        {
            if (node == null) return;
            foreach (var child in node.Neighbors) child.Neighbors.Remove(node);
            foreach (var friend in node.Friends) friend.Friends.Remove(node);
            node.Neighbors.Clear();
            node.Friends.Clear();
        }

        #region DFS
        private void DephtRecursive(Node node)
        {
            if (node == null || vector.Contains(node)) return;
            vector.Add(node);
            Console.WriteLine(node);
            foreach (var child in node.Neighbors) DephtRecursive(child);
            foreach (var friend in node.Friends) DephtRecursive(friend);
        }

        public void Depht(Node startNode = null)
        {
            vector = new HashSet<Node>();
            DephtRecursive(startNode ?? root);
        }
        #endregion

        #region BFS
        public void Width(Node startNode = null)
        {
            vector = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();

            Node start = startNode ?? root;
            queue.Enqueue(start);
            vector.Add(start);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine(current);
                foreach (var child in current.Neighbors)
                {
                    if (!vector.Contains(child))
                    {
                        vector.Add(child);
                        queue.Enqueue(child);
                    }
                }
                foreach (var friend in current.Friends)
                {
                    if (!vector.Contains(friend))
                    {
                        vector.Add(friend);
                        queue.Enqueue(friend);
                    }
                }
            }
        }
        #endregion

        // Найти самого популярного студента
        public Student GetPopularStudent()
        {
            if (vector == null || vector.Count == 0) Width();
            Node popular = root;
            foreach (var node in vector)
            {
                if (node.Friends.Count > popular.Friends.Count) popular = node;
            }
            return popular.Student;
        }
    }
}
