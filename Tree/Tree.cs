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

        //public Node CreateBalancedTree(int nodeCount)
        //{
        //    string text;
        //    Node root;
        //    if (nodeCount == 0) //базовый случай для остановки рекурсии
        //        root = null;
        //    else
        //    {
        //        Console.WriteLine("введите значения узла");
        //        text = Console.ReadLine();
        //        root = new Node(text);
        //        root.Left = CreateBalancedTree(nodeCount /  2);
        //        root.Right = CreateBalancedTree(nodeCount - nodeCount / 2 - 1); ;
        //    }

        //    return root;
        //}
        #region ДобавлениеУзла
        private Node AddNodeRecursive(Node node, People people)
        {
            if(node == null) //базовый случай - не встретилось совпадений
                return new Node(people);
            int result = string.Compare(node.People.Name, people.Name);
            if(result < 0)
                node.Left = AddNodeRecursive(node.Left, people);
            else if( result > 0)
                node.Right = AddNodeRecursive(node.Right, people);

            return node;
        }
        public void AddNode(People people ) =>
            Root = AddNodeRecursive(Root, people);
        #endregion

        #region Удаление узла
        private Node DeleteNodeRecursive(Node node, People people)
        {
            if (node == null) return null;
            int result = string.Compare(node.People.Name, people.Name);
            if(result < 0)
                node.Left = DeleteNodeRecursive(node.Left, people);
            else if(result > 0)
                node.Right = DeleteNodeRecursive(node.Right, people);
            else //удаление найденного элемента
            {
                if (node.Left == null)
                    return node.Right;
                else if(node.Right == null)
                    return node.Left;

                node.People = FindMinValue(node.Right);
                node.Right = DeleteNodeRecursive(node.Right, node.People);

            }
            return node;
        }
        private People FindMinValue(Node node)
        {
            People minValue = node.People;
            while(node.Left != null)
            {
                minValue = node.Left.People;
                node = node.Left;
            }
            return minValue;
        }
        public void DeleteNode(People people)=>
            Root = DeleteNodeRecursive(Root, people);
        #endregion

        #region ОбходДереваRLR
        private void TreeTravelsalRecursive(Node node, List<People> results)
        {
            if(node!=null)
            {
                results.Add(node.People);
                TreeTravelsalRecursive(node.Left, results);
                TreeTravelsalRecursive(node.Right, results);
            }
        }
        public List<People> TreeTraversal()
        {
            List<People> results = new();
            TreeTravelsalRecursive(Root, results);
            return results;
        }
        #endregion

        #region ПоискУзлаПоЗначению
        private bool FindNodeRecursive(Node node, People people)
        {
            if(node==null) return false;
            int resurt = string.Compare(node.People.Name, people.Name);
            if (resurt == 0)
                return true;
            else if (resurt < 0)
                return FindNodeRecursive(node.Left, people);
            else
                return FindNodeRecursive(node.Right, people);
        }
        public bool FindNode(People people) =>
            FindNodeRecursive(Root, people);

        public void AverageAge()
        {
            var list = TreeTraversal();
            float ages = 0;

            foreach (People people in list) 
            {
                ages += people.Age; 
            }

            Console.WriteLine($"средний возраст людей в дереве == {ages/list.Count}");
        }
        #endregion
    }

    
}
