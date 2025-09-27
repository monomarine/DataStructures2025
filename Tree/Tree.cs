using System;
using System.Collections.Generic;

namespace Tree
{
    /// <summary>
    /// Бинарное дерево поиска для хранения объектов Person.
    /// </summary>
    internal class Tree
    {
        /// <summary> Внутренний класс узла дерева. </summary>
        private class Node
        {
            public Person Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(Person value)
            {
                Value = value;
            }
        }

        private Node Root { get; set; }

        #region Добавление
        public void Add(Person person) =>
            Root = AddRecursive(Root, person);

        private Node AddRecursive(Node node, Person person)
        {
            if (node == null)
                return new Node(person);

            int result = string.Compare(
                person.Name, node.Value.Name, StringComparison.OrdinalIgnoreCase);

            if (result < 0)
                node.Left = AddRecursive(node.Left, person);
            else if (result > 0)
                node.Right = AddRecursive(node.Right, person);

            return node;
        }
        #endregion

        #region Удаление
        public void Delete(string name) =>
            Root = DeleteRecursive(Root, name);

        private Node DeleteRecursive(Node node, string name)
        {
            if (node == null) return null;

            int result = string.Compare(
                name, node.Value.Name, StringComparison.OrdinalIgnoreCase);

            if (result < 0)
                node.Left = DeleteRecursive(node.Left, name);
            else if (result > 0)
                node.Right = DeleteRecursive(node.Right, name);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node minNode = FindMin(node.Right);
                node.Value = minNode.Value;
                node.Right = DeleteRecursive(node.Right, minNode.Value.Name);
            }
            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
        #endregion

        #region Обход
        public List<Person> Traverse()
        {
            var list = new List<Person>();
            TraverseRecursive(Root, list);
            return list;
        }

        private void TraverseRecursive(Node node, List<Person> results)
        {
            if (node == null) return;

            TraverseRecursive(node.Left, results);
            results.Add(node.Value);
            TraverseRecursive(node.Right, results);
        }
        #endregion

        #region Средний возраст
        public double GetAverageAge()
        {
            var people = Traverse();
            if (people.Count == 0) return 0;

            double total = 0;
            foreach (var p in people)
                total += p.Age;

            return total / people.Count;
        }
        #endregion
    }
}
