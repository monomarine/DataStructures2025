using System.Collections.Immutable;
using System.Net.WebSockets;

namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
