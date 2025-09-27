namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Иван", DateTime.Parse("2005-04-20"));
            Student student2 = new Student("Петр", DateTime.Parse("2002-04-20"));
            Student student3 = new Student("Мария", DateTime.Parse("2001-04-20"));

            Tree tree = new Tree();
            tree.AddNode(student1);
            tree.AddNode(student2);
            tree.AddNode(student3);

            Console.WriteLine($"{tree.CalculateAverageAge():F1} лет");
            Console.ReadLine();
        }
    }
}