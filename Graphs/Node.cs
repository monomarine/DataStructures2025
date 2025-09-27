using System.Collections.Generic;

namespace Graphs
{
    internal class Node
    {
        public string Value { get; set; }
        public Student Student { get; set; }
        public List<Node> Neighbors { get; set; }
        public List<Node> Friends { get; set; }


        public Node(string value)
        {
            Value = value;
            Neighbors = new List<Node>();
            Friends = new List<Node>();
        }


        public Node(Student student)
        {
            Student = student;
            Neighbors = new List<Node>();
            Friends = new List<Node>();
        }

        public override string ToString()
        {
            return Student != null ? Student.ToString() : Value;
        }
    }
}
