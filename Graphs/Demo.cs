using System;

namespace Graphs
{
    internal class Demo
    {
        static void Main()
        {
            Console.WriteLine("=== Граф со студентами ===");

            Student Abdulov = new("Абдулов", "3пк2");
            Student Shirshikov = new("Ширшиков", "3пк2");
            Student Aniskov = new("Аниськов", "3пк2");
            Student Syndyukov = new("Сюндюков", "3пк2");
            Student Nikonov = new("Никонов", "3пк2");

            Abdulov.AddMark("Math", 4, 5, 3, 4);
            Shirshikov.AddMark("PE", 5, 4, 4, 3);
            Aniskov.AddMark("Math", 5, 5, 4, 5);
            Syndyukov.AddMark("History", 5, 5, 5, 4);
            Nikonov.AddMark("Math", 4, 4, 5, 3);

            GraphByList graph = new GraphByList(Abdulov);

            Node n1 = graph.AddNode(Shirshikov);
            Node n2 = graph.AddNode(Aniskov, n1);
            Node n3 = graph.AddNode(Syndyukov, n1);
            Node n4 = graph.AddNode(Nikonov, n3);

            graph.AddEdge(n3, n1);
            graph.AddEdge(n3, n2);
            graph.AddEdge(n3, n4);
            graph.AddEdge(n3, null);

            Console.WriteLine("\nBFS:");
            graph.Width();

            Console.WriteLine("\nDFS:");
            graph.Depht();

            Console.WriteLine($"\nСредняя оценка всех студентов: {Math.Round(Student.GetAverage(), 2)}");
            Console.WriteLine("Самый популярный студент: " + graph.GetPopularStudent());
        }
    }
}
