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
        public Node Root { get;  set; } //корень дерева
        public Tree()
        {
            Root = null;
        }

        public Node CreateBalancedTree(int nodeCount)
        {
            string name;
            DateTime birthDate;
            Node root;
            if (nodeCount == 0) //базовый случай для остановки рекурсии
                root = null;
            else
            {
                Console.WriteLine("введите ФИО человека");
                name = Console.ReadLine();
                Console.WriteLine("введите дату рождения (yyyy-MM-dd)");
                var dateText = Console.ReadLine();
                if (!DateTime.TryParse(dateText, out birthDate))
                    birthDate = DateTime.Today;
                root = new Node(new Person(name, birthDate));
                root.Left = CreateBalancedTree(nodeCount /  2);
                root.Right = CreateBalancedTree(nodeCount - nodeCount / 2 - 1); ;
            }

            return root;
        }
        #region ДобавлениеУзла
        private Node AddNodeRecursive(Node node, Person value)
        {
            if(node == null) //базовый случай - не встретилось совпадений
                return new Node(value);
            int result = string.Compare(node.Value.FullName, value.FullName);
            if(result < 0)
                node.Left = AddNodeRecursive(node.Left, value);
            else if( result > 0)
                node.Right = AddNodeRecursive(node.Right, value);

            return node;
        }
        public void AddPerson(Person value) =>
            Root = AddNodeRecursive(Root, value);
        public void AddNode(Person value) =>
            AddPerson(value);
        #endregion

        #region Удаление узла
        private Node DeleteNodeRecursive(Node node, string fullName)
        {
            if (node == null) return null;
            int result = string.Compare(node.Value.FullName, fullName);
            if(result < 0)
                node.Left = DeleteNodeRecursive(node.Left, fullName);
            else if(result > 0)
                node.Right = DeleteNodeRecursive(node.Right, fullName);
            else //удаление найденного элемента
            {
                if (node.Left == null)
                    return node.Right;
                else if(node.Right == null)
                    return node.Left;

                node.Value = FindMinValue(node.Right);
                node.Right = DeleteNodeRecursive(node.Right, node.Value.FullName);

            }
            return node;
        }
        private Person FindMinValue(Node node)
        {
            Node current = node;
            while (current.Left != null)
            {
                current = current.Left; 
            }
            return current.Value;
        }
        public void DeleteNode(string fullName)=>
            Root = DeleteNodeRecursive(Root, fullName);
        public void DeleteByName(string fullName)=>
            Root = DeleteNodeRecursive(Root, fullName);
        #endregion

        #region ОбходДереваRLR
        private void TreeTravelsalRecursive(Node node, List<Person> results)
        {
            if(node!=null)
            {
                results.Add(node.Value);
                TreeTravelsalRecursive(node.Left, results);
                TreeTravelsalRecursive(node.Right, results);
            }
        }
        public List<Person> TreeTraversal()
        {
            List<Person> results = new List<Person>();
            TreeTravelsalRecursive(Root, results);
            return results;
        }
        #endregion

        #region ПоискУзлаПоЗначению
        private bool FindNodeRecursive(Node node, string fullName)
        {
            if(node==null) return false;
            int resurt = string.Compare(node.Value.FullName, fullName);
            if (resurt == 0)
                return true;
            else if (resurt < 0)
                return FindNodeRecursive(node.Left, fullName);
            else
                return FindNodeRecursive(node.Right, fullName);
        }
        public bool FindNode(string fullName)=>
            FindNodeRecursive(Root, fullName);

        #endregion

        #region МетрикиВозрастов
        private void AggregateAges(Node node, ref int totalYears, ref int count)
        {
            if (node == null) return;
            totalYears += node.Value.AgeYears;
            count += 1;
            AggregateAges(node.Left, ref totalYears, ref count);
            AggregateAges(node.Right, ref totalYears, ref count);
        }

        public AgeStatistics GetAgeStatistics()
        {
            int totalYears = 0;
            int count = 0;
            AggregateAges(Root, ref totalYears, ref count);
            double average = count > 0 ? (double)totalYears / count : 0.0;
            return new AgeStatistics(totalYears, average, count);
        }
        #endregion
    }
}
