namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree peopleTree = new Tree();

<<<<<<< HEAD
             tree.AddNode("Tom");
             tree.AddNode("Bob");
             tree.AddNode("Mag");
            tree.AddNode("1");
            tree.AddNode("5");
            tree.AddNode("3");
            tree.AddNode("4");
            tree.AddNode("2");

            var res = tree.TreeTraversal();
            foreach (var item in res) 
                Console.WriteLine(item);

            tree.DeleteNode("1");
            var res2 = tree.TreeTraversal();
            foreach (var item in res2)
                Console.WriteLine(item);
=======
            peopleTree.AddNode("Иван", 45);
            peopleTree.AddNode("Мария", 30);
            peopleTree.AddNode("Петр", 55);
            peopleTree.AddNode("Анна", 25);
            peopleTree.AddNode("Сергей", 35);
            peopleTree.AddNode("Ольга", 50);
            peopleTree.AddNode("Алексей", 28);

            Console.WriteLine("Люди");
            var peopleList = peopleTree.TreeTraversal();
            foreach (var person in peopleList)
            {
                Console.WriteLine(person);
            }
            double averageAge = peopleTree.GetAverageAge();
            Console.WriteLine($"Средний возраст: {averageAge}");

>>>>>>> 5e4b100 (Утяпов Есет)
        }
    }
}
