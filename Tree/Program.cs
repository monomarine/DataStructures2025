namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = new Student("студент 0", "Студент");
            var graph = new StudentGraph(root);

            var s1 = new Student("студент 1", "Кирилл");
            var s2 = new Student("студент 2", "Василий");
            var s3 = new Student("студент 3", "Вальдемар");
            var s4 = new Student("студент 4", "Добрыня");

            graph.AddEdge(s1, s2); 
            graph.AddEdge(s2, s3);  
            graph.AddEdge(null, s4);
            graph.AddEdge(s1, null); 

            graph.Print();

            Console.WriteLine($"\nВсего студентов в графе: {graph.CountStudents()}");

            var (most, deg) = graph.GetMostSociable();
            Console.WriteLine(most is null
                ? "Граф пуст."
                : $"Самый общительный: {most}, связей: {deg}");
        }
    }
}
