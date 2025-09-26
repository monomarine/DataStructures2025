using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphByList
    {
        private Node root;
        private HashSet<Node> vector;

        public GraphByList(string rootStudentName, double rootGrade = 0.0)
        {
            this.root = new Node(rootStudentName, rootGrade);
        }

        public Node AddNode(string studentName, double grade = 0.0, Node parent = null)
        {
            Node newNode = new Node(studentName, grade);
            if (parent == null)
            {
                newNode.Neighbors.Add(root);
                root.Neighbors.Add(newNode);
            }
            else
            {
                newNode.Neighbors.Add(parent);
                parent.Neighbors.Add(newNode);
            }
            return newNode;
        }

        public void RemoveNode(Node node)
        {
            if (node == null) return;

            foreach (Node neighbor in node.Neighbors.ToList())
            {
                neighbor.Neighbors.Remove(node);
            }
            node.Neighbors.Clear();
        }

        #region ОбходВГлубину
        private void DepthRecursive(Node startNode)
        {
            if (startNode == null || vector.Contains(startNode)) return;

            vector.Add(startNode);
            Console.WriteLine($"{startNode.StudentName} (Оценка: {startNode.Grade})");

            foreach (Node child in startNode.Neighbors)
                DepthRecursive(child);
        }

        public void Depth(Node startNode = null)
        {
            vector = new HashSet<Node>();
            DepthRecursive(startNode ?? root);
        }
        #endregion

        #region ОбходВШирину
        public void Width(Node startNode = null)
        {
            Queue<Node> queue = new Queue<Node>();
            vector = new HashSet<Node>();

            Node start = startNode ?? root;
            queue.Enqueue(start);
            vector.Add(start);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine($"{current.StudentName} (Оценка: {current.Grade})");

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
        #endregion

        public void AddEdge(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return;

            if (n1 == null) n1 = root;
            if (n2 == null) n2 = root;

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

        private Node FindNodeRecursive(string findValue, Node startNode)
        {
            if (startNode == null || vector.Contains(startNode)) return null;

            vector.Add(startNode);
            if (startNode.StudentName == findValue)
                return startNode;

            foreach (Node child in startNode.Neighbors)
            {
                Node result = FindNodeRecursive(findValue, child);
                if (result != null) return result;
            }
            return null;
        }

        public Node FindNode(string findValue, Node startNode = null)
        {
            vector = new HashSet<Node>();
            return FindNodeRecursive(findValue, startNode ?? root);
        }

        public double CalculateAverageGrade()
        {
            if (root == null) return 0.0;

            vector = new HashSet<Node>();
            var (sum, count) = CalculateAverageGradeRecursive(root);
            return count > 0 ? sum / count : 0.0;
        }

        private (double sum, int count) CalculateAverageGradeRecursive(Node startNode)
        {
            if (startNode == null || vector.Contains(startNode)) return (0, 0);

            vector.Add(startNode);
            double sum = startNode.Grade;
            int count = 1;

            foreach (Node child in startNode.Neighbors)
            {
                var (childSum, childCount) = CalculateAverageGradeRecursive(child);
                sum += childSum;
                count += childCount;
            }

            return (sum, count);
        }

        public Node FindMostSociableStudent()
        {
            if (root == null) return null;

            vector = new HashSet<Node>();
            Node mostSociable = root;
            FindMostSociableStudentRecursive(root, ref mostSociable);
            return mostSociable;
        }

        private void FindMostSociableStudentRecursive(Node startNode, ref Node currentMostSociable)
        {
            if (startNode == null || vector.Contains(startNode)) return;

            vector.Add(startNode);

            if (startNode.Neighbors.Count > currentMostSociable.Neighbors.Count)
            {
                currentMostSociable = startNode;
            }

            foreach (Node child in startNode.Neighbors)
            {
                FindMostSociableStudentRecursive(child, ref currentMostSociable);
            }
        }

        public Node FindMostSociableStudentWidth()
        {
            if (root == null) return null;

            Queue<Node> queue = new Queue<Node>();
            vector = new HashSet<Node>();
            Node mostSociable = root;

            queue.Enqueue(root);
            vector.Add(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.Neighbors.Count > mostSociable.Neighbors.Count)
                {
                    mostSociable = current;
                }

                foreach (Node child in current.Neighbors)
                {
                    if (!vector.Contains(child))
                    {
                        vector.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return mostSociable;
        }

        public List<Node> GetAllNodes()
        {
            if (root == null) return new List<Node>();

            vector = new HashSet<Node>();
            List<Node> allNodes = new List<Node>();
            GetAllNodesRecursive(root, allNodes);
            return allNodes;
        }

        private void GetAllNodesRecursive(Node startNode, List<Node> nodesList)
        {
            if (startNode == null || vector.Contains(startNode)) return;

            vector.Add(startNode);
            nodesList.Add(startNode);

            foreach (Node child in startNode.Neighbors)
            {
                GetAllNodesRecursive(child, nodesList);
            }
        }
        public int GetNodesCount()
        {
            return GetAllNodes().Count;
        }

        public bool HasCycle()
        {
            if (root == null) return false;

            vector = new HashSet<Node>();
            return HasCycleRecursive(root, null);
        }

        private bool HasCycleRecursive(Node currentNode, Node parent)
        {
            if (currentNode == null) return false;

            vector.Add(currentNode);

            foreach (Node neighbor in currentNode.Neighbors)
            {
                if (!vector.Contains(neighbor))
                {
                    if (HasCycleRecursive(neighbor, currentNode))
                        return true;
                }
                else if (neighbor != parent)
                {
                    return true;
                }
            }

            return false;
        }
    }
}