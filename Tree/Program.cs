using System;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            tree.Add(new Person("Иван", new DateTime(1990, 5, 12)));
            tree.Add(new Person("Ольга", new DateTime(1985, 7, 1)));
            tree.Add(new Person("Сергей", new DateTime(2000, 3, 22)));
            tree.Add(new Person("Анна", new DateTime(1995, 1, 15)));
            tree.Add(new Person("Елена", new DateTime(2010, 6, 10)));
            tree.Add(new Person("Михаил", new DateTime(1978, 12, 5)));

            Console.WriteLine("Обход дерева (по имени):");
            foreach (var person in tree.Traverse())
                Console.WriteLine(person);

            Console.WriteLine($"\nСредний возраст: {tree.GetAverageAge():F1} лет");

            tree.Delete("Анна");
            Console.WriteLine("\nПосле удаления Анны:");
            foreach (var person in tree.Traverse())
                Console.WriteLine(person);

            Console.WriteLine($"\nНовый средний возраст: {tree.GetAverageAge():F1} лет");
        }
    }
}
