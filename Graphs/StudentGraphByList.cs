using System;
using System.Collections.Generic;

namespace Graphs
{
    internal class StudentNode
    {
        public Student Value { get; set; }     // узел хранит объект студента
        public List<StudentNode> Neighbors { get; set; } 

        public StudentNode(Student value)
        {
            Value = value;
            Neighbors = new List<StudentNode>();   
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "<null>";  
        }
    }

    internal class StudentGraphByList
    {
        private StudentNode root;                   
        private HashSet<StudentNode> vector;      

        public StudentGraphByList(Student rootStudent)
        {
            root = new StudentNode(rootStudent);    
        }

        public StudentNode AddNode(Student student, StudentNode parent = null)
        {
            StudentNode newNode = new StudentNode(student); 
            if (parent == null)
            {
                // если родитель не указан, связываем новый узел с корнем
                newNode.Neighbors.Add(root);
                root.Neighbors.Add(newNode);
            }
            else
            {
                // иначе связываем с указанным родителем
                newNode.Neighbors.Add(parent);
                parent.Neighbors.Add(newNode);
            }
            return newNode; 
        }

        public void AddEdge(StudentNode n1, StudentNode n2)
        {
           
            if (n1 == null && n2 == null) return;
            if (n1 == null) n1 = root;
            if (n2 == null) n2 = root;

            if (!n1.Neighbors.Contains(n2)) n1.Neighbors.Add(n2);
            if (!n2.Neighbors.Contains(n1)) n2.Neighbors.Add(n1);
        }

        
        public StudentNode FindMostSocial(StudentNode startNode = null)
        {
            // обход в ширину для поиска узла с максимальной количеством соседей
            Queue<StudentNode> queue = new Queue<StudentNode>();
            vector = new HashSet<StudentNode>();

            StudentNode start = startNode ?? root;
            queue.Enqueue(start);
            vector.Add(start);

            StudentNode best = start;              
            int bestDegree = start.Neighbors.Count; 

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int degree = current.Neighbors.Count;  

                // если нашли узел с большей степенью делаем обновление
                if (degree > bestDegree)
                {
                    bestDegree = degree;
                    best = current;
                }

                foreach (var child in current.Neighbors)
                {
                    if (!vector.Contains(child))
                    {
                        vector.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            return best; 
        }

        public List<StudentNode> GenerateStudents(int count, int seed = 0)
        {
            // генерация случайного графа студентов 
            var rnd = seed == 0 ? new Random() : new Random(seed); 
            var nodes = new List<StudentNode>();

            string[] names = { "Алексей", "Мария", "Иван", "Анна", "Дмитрий", "Екатерина", "Сергей", "Ольга", "Павел", "Юлия" };

            for (int i = 0; i < count; i++)
            {
                // генерация имени и значения для студента
                string name = names[rnd.Next(names.Length)] + " " + (char)('A' + rnd.Next(0, 26)) + ".";
                double gpa = Math.Round(2.0 + rnd.NextDouble() * 3.0, 2); 

                var student = new Student(name, gpa); 

                StudentNode parent = null;
                if (nodes.Count > 0 && rnd.NextDouble() < 0.8)
                {
                    parent = nodes[rnd.Next(nodes.Count)];
                }

                var newNode = AddNode(student, parent); 
                nodes.Add(newNode);                     
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                if (i + 1 < nodes.Count && rnd.NextDouble() < 0.5) AddEdge(nodes[i], nodes[i + 1]);
                if (i + 2 < nodes.Count && rnd.NextDouble() < 0.3) AddEdge(nodes[i], nodes[i + 2]);
            }
            return nodes; 
        }

        public void Width(StudentNode node = null)
        {
            Queue<StudentNode> queue = new Queue<StudentNode>();
            vector = new HashSet<StudentNode>();

            StudentNode start = node ?? root;
            queue.Enqueue(start);
            vector.Add(start);
            double sum = 0.0;
            int count = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                double avg = current.Value.Average();
                Console.WriteLine($"Средний балл \"{current.Value.Name}\" - {avg:F2}");
                sum += avg;
                count++;

                foreach (var child in current.Neighbors)
                {
                    if (!vector.Contains(child))
                    {
                        vector.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            double overall = count == 0 ? 0.0 : sum / count;
            Console.WriteLine($"Средняя успеваемость всех студентов: {overall:F2}");
        }
    }
}
