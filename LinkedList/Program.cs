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
            list.AddLast("5");
            list.AddLast("6");
            string lastElement = list.GetLast(); 
            Console.WriteLine(lastElement);
            list.RemoveFirst();
            list.InsertAfter("3", "66");
            
            foreach (var i in list)
                Console.WriteLine(i);

            list.Reverse();

                 foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
