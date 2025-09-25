using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphByList
    {
        private Node root; //самый первый узел добавленный в граф
        private HashSet<Node> vector;

        // добавил список для простого хранения всех студентов без связей 
        private List<Node> nodes = new List<Node>();
        public GraphByList(Student rootStudent)
        {
            this.root = new Node(rootStudent);
        }
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
            nodes.Add(newNode);
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
            nodes.Remove(node);
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
                Console.WriteLine(current.Student.Name);
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
            if (n1 == null || n2 == null) return;
            if (n1 == null)
            {
                n1.Neighbors.Add(root);
                root.Neighbors.Add(n1);
            }
            if (n2 == null)
            {
                n2.Neighbors.Add(root);
                root.Neighbors.Add(n2);
            }
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

        private Node FindNodeRecursive(string findName, Node startNode)
        {
            if (startNode == null || vector.Contains(startNode)) return null; //базовый случа й

            vector.Add(startNode);
            if (startNode.Student.Name == findName)
                return startNode;

            foreach (Node child in startNode.Neighbors)
            {
                Node result = FindNodeRecursive(findName, child);
                if (result != null) return result;
            }
            return null;
        }
        public Node FindNode(string findName, Node startNode = null)
        {
            vector = new HashSet<Node>();
            return FindNodeRecursive(findName, startNode);
        }

        /// <summary>
        /// Метод для вычисления средней оценки
        /// по сути, нам здесь не нужны связи, просто получаем нужных студентов, вытаскиваем их оценки, соединяем все оценки,
        /// складываем оценки и делим на их количества для получения среднего арифметического числа
        /// </summary>
        /// <param name="subject"> передмет  о котором ищем среднуюю оценку </param>
        /// <param name="students"> передаем массив студентов, чью среднюю оценку считаем </param>
        /// <returns> возвращаем дробное число </returns>
        public float AverageMark(string subject, params Student[] students)
        {
           // список для хранения всех оценок
            List<int> fullMark = new List<int>();
            
            // проходим по всем студентам которые пришли в метод
            foreach (Student node in students)
            {

                // проверяем есть ли в словаре студента нужный предмет
                if (node.Mark.ContainsKey(subject))
                {
                    // создаем новый список и сохраняем туда оценки студента по ключу предмета
                    List<int> markSrudent = node.Mark[subject];

                    // пробегаем по полученному списку оценок и добавляем им их в список общих оценок
                    foreach (int i in markSrudent)
                    {
                        fullMark.Add(i);
                    }
                }
            }

            // узнаем количество всех оценок
            float len = fullMark.Count;

            
            // складываем все оценки 
            float average = 0;
            foreach (int i in fullMark)
            {
                average += i;
            }

            // ищем среднюю оценку
            float ave = average / len;

            // возвращаем полученное значение
            return ave;
        }

        /// <summary>
        /// метод для поиска самого популярного студента
        /// тут похоже, нам не нужны связи, нам нужно их количество у студентов
        /// </summary>
        public void Popular()
        {   
            // создаем стартового студента
            Node current = root;
            
            // пробегаем по всем студентам в графе
            foreach (var v in nodes)
            {
                // если количество связей следующего студента в списке студентов, больше чем стартового студента, то перезаписываем и идем дальше
                if (v.Neighbors.Count > current.Neighbors.Count)
                {
                    current = v;
                }
            }
            // выводим в консоль имя самого Ш-Общительного
            Console.WriteLine(current.Student.Name);
        }
    }
}
