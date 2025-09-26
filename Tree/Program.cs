namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            People nikita = new("Nikita", new(2007, 1, 3));
            People danil = new("Danil", new(2007, 10, 20));
            People blad = new("Vlad", new(2010, 5, 14));
            People tim = new("Тимоха", new(2011, 5, 14));

             tree.AddNode(nikita);
             tree.AddNode(danil);
             tree.AddNode(blad);
             tree.AddNode(tim);


            var res = tree.TreeTraversal();
            tree.AverageAge();

            tree.DeleteNode(nikita);

            foreach (var item in res) 
                Console.WriteLine(item);
            Console.ReadKey();
           
        }
    }
}
