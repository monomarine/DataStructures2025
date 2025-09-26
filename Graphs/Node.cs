using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Node
    {
        public string StudentName { get; set; }
        public double Grade { get; set; }
        public List<Node> Neighbors { get; set; }

        public Node(string studentName, double grade = 0.0)
        {
            StudentName = studentName;
            Grade = grade;
            Neighbors = new List<Node>();
        }

        public override string ToString() => $"{StudentName} (Средний балл: {Grade:F2})";
    }
}