using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Node
    {
        // заменили строку на студента
        public Student Student { get; set; }
        public List<Node> Neighbors { get; set; }

        public Node(Student value)
        {
            Student = value;  
            Neighbors = new List<Node>();
        }

        /// <summary>
        /// выводим всю информацию об студенте
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info =  Student.Name + "\n" + Student.Group + "\n" + Student.Mark;
            return info;
        }
    }
}
