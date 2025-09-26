using Graphs;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создание учеников и их оценок
            Student Danil = new Student("Danil", "3pk1");
            List<int> markDanil = new List<int>() { 5, 5, 2, 3 };
            Danil.AddMark("rus", markDanil);

            Student Timofey = new Student("Tinoshka", "3pk1");
            List<int> markTimofey = new List<int>() { 0, 0, 0, 0 };
            Timofey.AddMark("rus", markTimofey);

            Student Nikita = new Student("NIkita", "3pk2");
            List<int> markNikita = new List<int>() { 5, 2, 2, 2 };
            Nikita.AddMark("rus", markNikita);

            Student Egor = new Student("Egor", "1pk1");
            List<int> markEgor = new List<int>() { 5, 5, 4 };
            Egor.AddMark("rus", markEgor);

            Student Blad = new Student("Blad", "3pk1");
            List<int> marlVlad = new List<int>() { 5, 5, 2, 3, 4, 4, 5, 5, 5 };
            Blad.AddMark("rus", marlVlad);

            // создаем точек
            GraphByList graph = new GraphByList(Danil);
            Node t = graph.AddNode(Timofey);
            Node v = graph.AddNode(Blad, t);
            Node e = graph.AddNode(Egor, t);
            Node n = graph.AddNode(Nikita, t);

            // создание связей
            graph.AddEdge(t, n);
            graph.AddEdge(t, e);
            graph.AddEdge(t, v);
            graph.AddEdge(e, v);

            // средняя оценка
            var o = graph.AverageMark("rus", Egor, Nikita, Timofey, Blad);
            Console.WriteLine(o);

            // нахождение самого общительного студента
            graph.Popular();
        }
    }
}
