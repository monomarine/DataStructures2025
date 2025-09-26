using System;

namespace Tree
{
    internal class Person
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public int AgeYears
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age < 0 ? 0 : age;
            }
        }

        public Person(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FullName} ({BirthDate:yyyy-MM-dd}, {AgeYears} лет)";
        }
    }
}


