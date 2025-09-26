using System;
using System.Collections.Generic;

namespace Tree
{
    internal class Tree
    {
        public Node Root { get; private set; }

        public Tree()
        {
            Root = null;
        }

        #region Добавление узла
        private Node AddNodeRecursive(Node node, Person person)
        {
            if (node == null)
                return new Node(person);

            int result = string.Compare(person.Name, node.Value.Name, StringComparison.OrdinalIgnoreCase);
            if (result < 0)
                node.Left = AddNodeRecursive(node.Left, person);
            else if (result > 0)
                node.Right = AddNodeRecursive(node.Right, person);
            // Если имена одинаковы – не добавляем дубликаты

            return node;
        }

        public void AddNode(Person person) =>
            Root = AddNodeRecursive(Root, person);
        #endregion

        #region Удаление узла
        private Node DeleteNodeRecursive(Node node, string name)
        {
            if (node == null) return null;

            int result = string.Compare(name, node.Value.Name, StringComparison.OrdinalIgnoreCase);
            if (result < 0)
                node.Left = DeleteNodeRecursive(node.Left, name);
            else if (result > 0)
                node.Right = DeleteNodeRecursive(node.Right, name);
            else
            {
                // Найден узел для удаления
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Минимальный по имени узел из правого поддерева
                Node minNode = FindMinNode(node.Right);
                node.Value = minNode.Value;
                node.Right = DeleteNodeRecursive(node.Right, minNode.Value.Name);
            }
            return node;
        }

        private Node FindMinNode(Node node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        public void DeleteNode(string name) =>
            Root = DeleteNodeRecursive(Root, name);
        #endregion

        #region Обход дерева (прямой)
        private void TreeTraversalRecursive(Node node, List<Person> results)
        {
            if (node != null)
            {
                results.Add(node.Value);
                TreeTraversalRecursive(node.Left, results);
                TreeTraversalRecursive(node.Right, results);
            }
        }

        public List<Person> TreeTraversal()
        {
            var results = new List<Person>();
            TreeTraversalRecursive(Root, results);
            return results;
        }
        #endregion

        #region Средний возраст
        public double GetAverageAge()
        {
            var people = TreeTraversal();
            if (people.Count == 0) return 0;
            double total = 0;
            foreach (var p in people)
                total += p.Age;
            return total / people.Count;
        }
        #endregion
    }
}
