using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    internal class Student
    {
        public string Name { get; }
        public string Group { get; }
        private Dictionary<string, List<int>> _marks;
        private static List<Student> _students = new List<Student>();

        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            _marks = new Dictionary<string, List<int>>();
            _students.Add(this);
        }

        public void AddMark(string subject, params int[] marks)
        {
            if (!_marks.ContainsKey(subject))
                _marks[subject] = new List<int>(marks);
            else
                _marks[subject].AddRange(marks);
        }

        public static double GetAverage()
        {
            double total = 0;
            double count = 0;
            foreach (var student in _students)
            {
                foreach (var marks in student._marks.Values)
                {
                    total += marks.Sum();
                    count += marks.Count;
                }
            }
            return count == 0 ? 0 : total / count;
        }

        public override string ToString() => Name;
    }
}
