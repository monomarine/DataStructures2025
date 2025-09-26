using Graphs;
using System;

namespace GraphApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphByList studentGraph = new GraphByList("Иван Иванов", 4.5);

            Node petr = studentGraph.AddNode("Петр Петров", 4.2);
            Node maria = studentGraph.AddNode("Мария Сидорова", 4.8, petr);
            Node alexey = studentGraph.AddNode("Алексей Козлов", 3.9, petr);
            Node elena = studentGraph.AddNode("Елена Новикова", 4.6, maria);

            studentGraph.AddEdge(maria, alexey);
            studentGraph.AddEdge(elena, alexey);

            Console.WriteLine("=== Обход в глубину ===");
            studentGraph.Depth();

            Console.WriteLine("\n=== Обход в ширину ===");
            studentGraph.Width();

            Console.WriteLine($"\n=== Статистика ===");
            Console.WriteLine($"Количество студентов: {studentGraph.GetNodesCount()}");
            Console.WriteLine($"Средняя успеваемость: {studentGraph.CalculateAverageGrade():F2}");

            Node mostSociable = studentGraph.FindMostSociableStudent();
            Console.WriteLine($"Самый общительный студент: {mostSociable.StudentName}");
            Console.WriteLine($"Количество связей: {mostSociable.Neighbors.Count}");

            Console.WriteLine($"Граф содержит цикл: {studentGraph.HasCycle()}");

            Node found = studentGraph.FindNode("Мария Сидорова");
            if (found != null)
                Console.WriteLine($"Найден студент: {found.StudentName} с оценкой {found.Grade}");
        }
    }
}