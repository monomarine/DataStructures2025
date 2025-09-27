using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Student
    {
        public string Name { get; set; }
        public double GradeAverage { get; set; } 

        public Student(string name, double gpa)
        {

            Name = name;
            GradeAverage = gpa;
        }

        public override string ToString() => $"{Name} (Ср успеваемость: {GradeAverage})";
    }
}
