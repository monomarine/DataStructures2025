using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class StudentGraph
    {
        private readonly Dictionary<Student, HashSet<Student>> _adj = new();

        public Student Root { get; private set; }

        public StudentGraph(Student root)
        {
            Root = root ?? throw new ArgumentNullException(nameof(root));
            _adj[root] = new HashSet<Student>();
        }

        public void AddStudent(Student s)
        {
            if (s is null) throw new ArgumentNullException(nameof(s));
            if (!_adj.ContainsKey(s))
                _adj[s] = new HashSet<Student>();
        }

        public void AddEdge(Student a, Student b)
        {
            if (a is null && b is null)
                throw new ArgumentException("Обе конечные точки равны нулю — невозможно добавить ребро.");

            a ??= Root; 
            b ??= Root; 

            if (a.Equals(b))
                return; 

            AddStudent(a);
            AddStudent(b);

            _adj[a].Add(b);
            _adj[b].Add(a);
        }

        public int CountStudents() => _adj.Count;

        public (Student student, int degree) GetMostSociable()
        {
            if (_adj.Count == 0) return (null, 0);

            Student best = null;
            int bestDeg = -1;

            foreach (var kv in _adj)
            {
                int deg = kv.Value.Count;
                if (deg > bestDeg)
                {
                    bestDeg = deg;
                    best = kv.Key;
                }
            }
            return (best, bestDeg);
        }

        public void Print()
        {
            Console.WriteLine("Граф:");
            foreach (var (student, neighbors) in _adj)
            {
                var list = string.Join(", ", neighbors.Select(n => n.ToString()));
                Console.WriteLine($"  {student}: [{list}]");
            }
        }
    }
}
