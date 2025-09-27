using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Student
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public Student(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate.Date; 
        }
    }
}