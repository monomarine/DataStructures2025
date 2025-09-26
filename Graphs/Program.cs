using Graphs;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[,] a = { { 0,0,0,0},
                         { 0,0,1,0},
                         { 1,0,0,0},
                         { 1,0,1,0}
                        };

            GraphByMatrix graph = new GraphByMatrix(a);
            graph.Depth(0);*/

            GraphByList graph = new GraphByList("Москва");
            Node n1 = graph.AddNode("Санкт-Петербург");
            Node n2 = graph.AddNode("Оренбург", n1);
            Node n3 = graph.AddNode("Омск", n1);
            Node n4 = graph.AddNode("Уфа", n2);
            graph.AddEdge(n1, n3);
            graph.AddEdge(n4, n3);

            graph.Width();

            var rnd = new Random();
            string[] names = { "Анна", "Дмитрий", "Юлия", "Сергей", "Алексей", "Мария", "Павел", "Ольга" };
            string Suffix() { return " " + (char)('А' + rnd.Next(0, 26)) + "."; }
            double G() { return Math.Round(2.0 + rnd.NextDouble() * 3.0, 2); }

            var sGraph = new StudentGraphByList(new Student(names[rnd.Next(names.Length)] + Suffix(), G(), G(), G()));
            var s1 = sGraph.AddNode(new Student(names[rnd.Next(names.Length)] + Suffix(), G(), G(), G()));
            var s2 = sGraph.AddNode(new Student(names[rnd.Next(names.Length)] + Suffix(), G(), G(), G()), s1);
            var s3 = sGraph.AddNode(new Student(names[rnd.Next(names.Length)] + Suffix(), G(), G(), G()), s1);
            var s4 = sGraph.AddNode(new Student(names[rnd.Next(names.Length)] + Suffix(), G(), G(), G()), s2);
            sGraph.AddEdge(s1, s3);
            sGraph.AddEdge(s4, s3);

            Console.WriteLine("\nСтуденты:");
            sGraph.Width();

            var most = sGraph.FindMostSocial();
            Console.WriteLine($"Самый общительный студент: {most.Value.Name}. Количество соседей: {most.Neighbors.Count}");
        }
    }
}
