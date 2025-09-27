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
        public Node Root { get; set; } //корень дерева
        public Tree()
        {
            Root = null;
        }

        public Node CreateBalancedTree(int nodeCount)
        {
            Student student;
            Node root;
            if (nodeCount == 0) //базовый случай для остановки рекурсии
                root = null;
            else
            {
                Console.WriteLine("введите имя студента");
                string name = Console.ReadLine();
                Console.WriteLine("введите дату рождения (гггг-мм-дд)");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                student = new Student(name, birthDate);
                root = new Node(student);
                root.Left = CreateBalancedTree(nodeCount / 2);
                root.Right = CreateBalancedTree(nodeCount - nodeCount / 2 - 1); ;
            }

            return root;
        }
        #region ДобавлениеУзла
        private Node AddNodeRecursive(Node node, Student student)
        {
            if (node == null) //базовый случай - не встретилось совпадений
                return new Node(student);
            int result = string.Compare(node.Value.Name, student.Name);
            if (result > 0)
                node.Left = AddNodeRecursive(node.Left, student);
            else if (result < 0)
                node.Right = AddNodeRecursive(node.Right, student);

            return node;
        }
        public void AddNode(Student student) =>
            Root = AddNodeRecursive(Root, student);
        #endregion

        #region Удаление узла
        private Node DeleteNodeRecursive(Node node, string name)
        {
            if (node == null) return null;
            int result = string.Compare(name, node.Value.Name);
            if (result < 0)
                node.Left = DeleteNodeRecursive(node.Left, name);
            else if (result > 0)
                node.Right = DeleteNodeRecursive(node.Right, name);
            else //удаление найденного элемента
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                node.Value = FindMinValue(node.Right);
                node.Right = DeleteNodeRecursive(node.Right, node.Value.Name);
            }
            return node;
        }
        private Student FindMinValue(Node node)
        {
            Node current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Value;
        }
        public void DeleteNode(string name) =>
            Root = DeleteNodeRecursive(Root, name);
        #endregion

        #region ОбходДереваRLR
        private void TreeTravelsalRecursive(Node node, List<Student> results)
        {
            if (node != null)
            {
                results.Add(node.Value);
                TreeTravelsalRecursive(node.Left, results);
                TreeTravelsalRecursive(node.Right, results);
            }
        }
        public List<Student> TreeTraversal()
        {
            List<Student> results = new List<Student>();
            TreeTravelsalRecursive(Root, results);
            return results;
        }
        #endregion

        #region ПоискУзлаПоЗначению
        private bool FindNodeRecursive(Node node, string name)
        {
            if (node == null) return false;
            int resurt = string.Compare(node.Value.Name, name);
            if (resurt == 0)
                return true;
            else if (resurt < 0)
                return FindNodeRecursive(node.Left, name);
            else
                return FindNodeRecursive(node.Right, name);
        }
        public bool FindNode(string name) =>
            FindNodeRecursive(Root, name);
        #endregion

        public double CalculateAverageAge()
        {
            if (Root == null) return 0;
            List<Student> students = TreeTraversal();
            double totalAge = 0;
            foreach (var student in students)
            {
                totalAge += student.Age;
            }
            return totalAge / students.Count;
        }
    }
}