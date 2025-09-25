using LinkedList;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SLinkedList list = new SLinkedList();
            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.AddLast("4");

            Console.WriteLine("Первый элемент: " + list.GetFirst());
            Console.WriteLine("Последний элемент: " + list.GetLast());

            list.RemoveFirst();
            list.RemoveByValue("4");

            Console.WriteLine("\nСписок после удаления:");
            foreach (var i in list)
                Console.WriteLine(i);

            list.Reverse();
            Console.WriteLine("\nПосле реверса:");
            foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
