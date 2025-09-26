using System;

namespace Tree
{
    internal class AgeStatistics
    {
        public int TotalYears { get; }
        public double AverageYears { get; }
        public int PeopleCount { get; }

        public AgeStatistics(int totalYears, double averageYears, int peopleCount)
        {
            TotalYears = totalYears;
            AverageYears = averageYears;
            PeopleCount = peopleCount;
        }

        public override string ToString()
        {
            return $"Всего лет: {TotalYears}, ср. возраст: {AverageYears:F1}, людей: {PeopleCount}";
        }
    }
}


