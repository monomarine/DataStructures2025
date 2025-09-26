using System;
using System.Collections.Generic;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            // Добавляем людей
            tree.AddNode(new Person("Tom", new DateTime(1990, 5, 12)));
            tree.AddNode(new Person("Bob", new DateTime(1985, 7, 1)));
            tree.AddNode(new Person("Mag", new DateTime(2000, 3, 22)));
            tree.AddNode(new Person("Alice", new DateTime(1995, 1, 15)));
            tree.AddNode(new Person("Eve", new DateTime(2010, 6, 10)));
            tree.AddNode(new Person("Chris", new DateTime(1978, 12, 5)));

            Console.WriteLine("Обход дерева (имена):");
            foreach (var person in tree.TreeTraversal())
                Console.WriteLine($"{person.Name} ({person.BirthDate:yyyy-MM-dd})");

            Console.WriteLine($"\nСредний возраст: {tree.GetAverageAge():F1} лет");

            // Удаление
            tree.DeleteNode("Alice");
            Console.WriteLine("\nПосле удаления Alice:");
            foreach (var person in tree.TreeTraversal())
                Console.WriteLine($"{person.Name} ({person.BirthDate:yyyy-MM-dd})");

            Console.WriteLine($"\nНовый средний возраст: {tree.GetAverageAge():F1} лет");
        }
    }
}
