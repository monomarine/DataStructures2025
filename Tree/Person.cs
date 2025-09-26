using System;

namespace Tree
{
    internal class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        /// <summary> Возраст на текущий момент в годах. </summary>
        public double Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public override string ToString() => $"{Name} ({BirthDate:yyyy-MM-dd})";
    }
}
