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
            list.AddFirst("1");
            list.AddFirst("5");
            list.AddFirst("6");

            /// list.InsertAfter("3", "66");
            ///foreach (var i in list)
            ///  Console.WriteLine(i);

            ///list.Reverse();

            ///foreach (var i in list)
            /// Console.WriteLine(i);

            ///list.RemoveFirst();
            ///foreach (var i in list)
            ///  Console.WriteLine(i);

            list.RemoveData("1");
            foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
