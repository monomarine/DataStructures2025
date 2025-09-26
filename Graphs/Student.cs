using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// класс Студента
    /// класс хранит Имя студента. группу, и словарь с оценками
    /// </summary>
    internal class Student
    {
        
        public string Name { get; set; }
        public string Group { get; set; }
        public Dictionary<string, List<int>> Mark { get; set; } = new Dictionary<string, List<int>>();

        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            

        }

        /// <summary>
        /// метод добавления оценок
        /// </summary>
        /// <param name="subject"> ключ предмета куда добавить оценки</param>
        /// <param name="marks"> список оценок</param>
        public void AddMark(string subject, List<int> marks)
        {
            if (Mark == null)
            {
                Mark = new Dictionary<string, List<int>>();
            }
            if (Mark.ContainsKey(subject))
            {
                Mark[subject] = marks;
            }
            else
            {
                Mark.Add(subject, marks);
            }

        }


    }
}
