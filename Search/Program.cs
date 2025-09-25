using System.Collections.Immutable;
using System.Net.WebSockets;

namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = 64655;
            int[] data = GetArray(25231165, key);

            
            Console.WriteLine();
            Console.WriteLine(Search.IterativeBinarySearch(key, data));
            Console.WriteLine(Search.LinearSearch(key, data));
            Console.WriteLine(Search.InterpolateSearch(key, data));
        }

        static int[] GetArray(int count, int key)
        {
            int[] array = new int[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = rand.Next(0, key);
            }
            array[count - 1] = key;
            Array.Sort(array);
            return array;
        }
       
    }
}
