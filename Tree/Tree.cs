using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Tree
    {
        public Node Root { get;  set; } //корень дерева
        public People PeopleOne { get; set; }
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
        #region ДобавлениеУзла
        private People AddNodeRecursive(People node, string name, int age)
        {
<<<<<<< HEAD
            if(node == null) //базовый случай - не встретилось совпадений
                return new Node(text);
            int result = string.Compare(node.Value, text);
            if(result > 0)
                node.Left = AddNodeRecursive(node.Left, text);
            else if( result < 0)
                node.Right = AddNodeRecursive(node.Right, text);
=======
            if (node == null)
                return new People(name, age: age);

            int result = string.Compare(node.Name, name);

            if (result < 0)
                node.Left = AddNodeRecursive(node.Left, name, age);
            else if (result > 0)
                node.Right = AddNodeRecursive(node.Right, name, age);
>>>>>>> 5e4b100 (Утяпов Есет)

            return node;
        }

        public void AddNode(string name, int age) =>
            PeopleOne = AddNodeRecursive(PeopleOne, name, age);
        #endregion

        #region Удаление узла
        private Node DeleteNodeRecursive(Node node, string text)
        {
            if (node == null) return null;
            int result = string.Compare(text, node.Value);
            if(result < 0)
                node.Left = DeleteNodeRecursive(node.Left, text);
            else if(result > 0)
                node.Right = DeleteNodeRecursive(node.Right, text);
            else //удаление найденного элемента
            {
                if (node.Left == null)
                    return node.Right;
                else if(node.Right == null)
                    return node.Left;

                node.Value = FindMinValue(node.Right);
                node.Right = DeleteNodeRecursive(node.Right, node.Value);

            }
            return node;
        }
        private string FindMinValue(Node node)
        {
            Node current = node;
            while (current.Left != null)
            {
                current = current.Left; 
            }
            return current.Value;
        }
        public void DeleteNode(string text)=>
            Root = DeleteNodeRecursive(Root, text);
        #endregion

        #region ОбходДереваRLR
        private void TreeTravelsalRecursive(People node, List<People> results)
        {
            if(node!=null)
            {
                results.Add(node);
                TreeTravelsalRecursive(node.Left, results);
                TreeTravelsalRecursive(node.Right, results);
            }
        }
        public List<People> TreeTraversal()
        {
            List<People> results = new List<People>();
            TreeTravelsalRecursive(PeopleOne, results);
            return results;
        }
        #endregion

        #region ПоискУзлаПоЗначению
        private bool FindNodeRecursive(Node node, string text)
        {
            if(node==null) return false;
            int resurt = string.Compare(node.Value, text);
            if (resurt == 0)
                return true;
            else if (resurt < 0)
                return FindNodeRecursive(node.Left, text);
            else
                return FindNodeRecursive(node.Right, text);
        }
        public bool FindNode(string text)=>
            FindNodeRecursive(Root, text);

        #endregion

        public double GetAverageAge()
        {
            List<People> allPeople = TreeTraversal();

            if (allPeople.Count == 0) return 0;

            int totalAge = 0;
            foreach (People person in allPeople)
            {
                totalAge += person.age;
            }

            return (double)totalAge / allPeople.Count;
        }
    }
}
