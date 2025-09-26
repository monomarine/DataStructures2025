using Graphs;

namespace Graph
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            /*int[,] a = { { 0,0,0,0},
                   { 0,0,1,0},
                   { 1,0,0,0},
                   { 1,0,1,0}
                  };

            GraphByMatrix graph = new GraphByMatrix(a);
            graph.Depth(1); */
            Student rootStudent = new Student("Иванов Иван Сергеевич", 5.0f);
            Student secondStudent = new Student("Сергеев Сергей Иванович", 3.8f);
            Student thirdStudent = new Student("Геннадьев Антон Викторович", 4.5f);
            Student fourthStudent = new Student("Куров Виктор Антонович", 4.0f);
            Student fifthStudent = new Student("Конев Александр Александрович", 4.5f);
            GraphByList graph = new(rootStudent);

            Node first = graph.AddNode(secondStudent);
            Node second = graph.AddNode(thirdStudent, first);
            Node third = graph.AddNode(fourthStudent, second);
            Node fourth = graph.AddNode(fifthStudent, second);

            Console.WriteLine("= Обход в ширину =");
            graph.Width();
          
            Console.WriteLine("=============");
            Console.WriteLine($"Общее количество баллов => {graph.ReceiveFullScore()}");
            Console.WriteLine($"Среднее количество баллов => {graph.ReceiveAverageScore()}");
            Console.WriteLine($"Самый общительный студент => {graph.FindNodeWithMostMembers()}");
		    }
    }
}