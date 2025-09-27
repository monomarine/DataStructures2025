using System;

namespace Tree
{
    /// <summary>
    /// Класс для хранения информации о человеке.
    /// </summary>
    internal class Person
    {
        public string Name { get; }
        public DateTime BirthDate { get; }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public override string ToString() =>
            $"{Name} ({BirthDate:yyyy-MM-dd}), возраст: {Age}";
    }
}
