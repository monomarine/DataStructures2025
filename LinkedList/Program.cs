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

            list.InsertAfter("3", "66");

            foreach (var i in list)
                Console.WriteLine(i);

            Console.WriteLine();

            list.Reverse();

            foreach (var i in list)
                Console.WriteLine(i);

            Console.WriteLine();

            Console.WriteLine(list.GetLast());

            Console.WriteLine();

            list.RemoveFirst();

            foreach (var i in list)
                Console.WriteLine(i);

            Console.WriteLine();

            list.Remove("2");

            foreach (var i in list)
                Console.WriteLine(i);

        }
    }
}
