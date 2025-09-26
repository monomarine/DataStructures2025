using LinkedList;
using System.Security.Cryptography.X509Certificates;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SLinkedList<string> list = new();
            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");

            list.InsertAfter("3", "66");
            
            foreach (var i in list)
                Console.WriteLine(i);

            list.Reverse();

                 foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
