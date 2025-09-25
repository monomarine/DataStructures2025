using System.Diagnostics;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetArray(10000);
            Console.WriteLine("до сортировки:");

            /*foreach (int i in array) 
                Console.Write(i+" ");*/

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Sort.QuickSort(array);
            timer.Stop();

            Console.WriteLine("\nпосле сортировки:");

            /*foreach (int i in array)
                Console.Write(i + " ");*/

            Console.WriteLine("затраченное время на сортировку: " + timer.ElapsedMilliseconds);
        }
        static int[] GetArray(int count)
        {
            int[] array = new int[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = rand.Next();
            }
            return array;
        }
    }
}
