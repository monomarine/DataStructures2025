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

            //GraphByList graph = new GraphByList("Москва");
            //Node n1 = graph.AddNode("Санкт-Петербург");
            //Node n2 = graph.AddNode("Оренбург", n1);
            //Node n3 = graph.AddNode("Омск", n1);

            //graph.AddEdge(n2, n3);

            //Node n4 = graph.AddNode("Уфа", n2);
            //graph.AddEdge(n4, n3);
            //graph.AddEdge(n4, n3);

            //graph.Width();

            //Console.WriteLine();

            //graph.Depht();


            GraphByList stdentGraph = new GraphByList(new Student("ivan", 4.5));
            Node st1 = stdentGraph.AddNode(new Student("maria", 4.7));
            Node st2 = stdentGraph.AddNode(new Student("sasha", 4.2), st1);
            Node st3 = stdentGraph.AddNode(new Student("anna", 4.9), st1);

            // связи
            stdentGraph.AddEdge(st2, st3);
            stdentGraph.AddEdge(null, st2);


            Console.WriteLine("Обход в ширину:");
            stdentGraph.Width();
            Console.WriteLine("\nОбход в глубину:");
            stdentGraph.Depht();

            Console.WriteLine($"\nСр успеваемость: {stdentGraph.CalculateAverage():F2}");

            Node mostSociable = stdentGraph.FindMostSociableStudent();
            Console.WriteLine($"Самый общительный студент: {mostSociable.Student.Name} " +
                              $"(связей: {mostSociable.Neighbors.Count})");
        }
    }
}
