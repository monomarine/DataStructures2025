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

            graph.AddEdge(n2, n3);

            Node n4 = graph.AddNode("Уфа", n2);
            graph.AddEdge(n4, n3);
            graph.AddEdge(n4, n3);

            graph.Width();

            Console.WriteLine();

            graph.Depht();
        }
    }
}
