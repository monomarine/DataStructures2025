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
        private Node root; //самый первый узел добавленный в граф
        private HashSet<Node> vector;

        public GraphByList(Student student)
        {
            this.root = new Node(student);
        }

        //public Node AddNode(string value, Node parent = null)
        //{
        //    Node newNode = new Node(value);
        //    if(parent == null)
        //    {
        //        newNode.Neighbors.Add(root);
        //        root.Neighbors.Add(newNode);
        //    }
        //    else
        //    {
        //        newNode.Neighbors.Add(parent);
        //        parent.Neighbors.Add(newNode);
        //    }
        //    return newNode;
        //}
        public Node AddNode(Student student, Node parent = null)
        {
            Node newNode = new Node(student);
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
            foreach (Node child in node.Neighbors)
            {
                child.Neighbors.Remove(node);
            }
            node.Neighbors.Clear();
            node = null;
        }
        #region ОбходВГлубину
        private void DephtRecursive(Node startNode)
        {
            if (startNode == null || vector.Contains(startNode)) return; //базовый случа й
            vector.Add(startNode);
            Console.WriteLine(startNode);
            foreach (Node child in startNode.Neighbors)
                DephtRecursive(child);
        }
        public void Depht(Node startNode = null)
        {
            vector = new HashSet<Node>();
            DephtRecursive(startNode ?? root);
        }
        #endregion

        #region ОбходВШиррину
        public void Width(Node node = null)
        {
            Queue<Node> queue = new Queue<Node>();
            vector = new HashSet<Node>();

            Node start = node ?? root;
            queue.Enqueue(start);
            vector.Add(start);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine(current.Student);
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
            if (n1 == null)
                n1 = root;

            if (n2 == null)
                n2 = root;

            if (n1 == n2)
                return;
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
            if (startNode == null || vector.Contains(startNode)) return null; //базовый случа й

            vector.Add(startNode);
            if (startNode.Student.Name == findValue)
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
            return FindNodeRecursive(findValue, startNode);
        }

        public double CalculateAverage()
        {
            HashSet<Node> visited = new HashSet<Node>();
            return CalculateAverageRecursive(root, visited);
        }

        private double CalculateAverageRecursive(Node currentNode, HashSet<Node> visited)
        {
            if (currentNode == null || visited.Contains(currentNode))
                return 0;

            visited.Add(currentNode);

            double totalGPA = currentNode.Student.GradeAverage;
            int count = 1;

            foreach (Node neighbor in currentNode.Neighbors)
            {
                var result = CalculateAverageRecursive(neighbor, visited);
                if (result > 0)
                {
                    totalGPA += result;
                    count++;
                }
            }

            return count > 1 ? totalGPA / count : totalGPA;
        }

        public Node FindMostSociableStudent()
        {
            if (root == null) return null;

            Node mostSociable = root;
            int maxConnections = root.Neighbors.Count;

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);
            visited.Add(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.Neighbors.Count > maxConnections)
                {
                    mostSociable = current;
                    maxConnections = current.Neighbors.Count;
                }

                foreach (Node neighbor in current.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return mostSociable;

        }

    }
}
