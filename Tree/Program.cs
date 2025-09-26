namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            Console.WriteLine("Введите количество человек:");
            var countText = Console.ReadLine();
            int count = 0;
            int.TryParse(countText, out count);
            tree.Root = tree.CreateBalancedTree(count);

            var res = tree.TreeTraversal();
            foreach (var person in res)
                Console.WriteLine(person);

            var stats = tree.GetAgeStatistics();
            Console.WriteLine(stats);

            Console.ReadKey();

        }
    }
}
