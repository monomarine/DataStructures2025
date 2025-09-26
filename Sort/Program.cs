using System.Diagnostics;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetArray(5, 10);
            Console.WriteLine("До сортировки: " + string.Join(" ", array));
            //Sort.BubbleSort(ref array);
            //Sort.SelectionSort(ref array);
            //Sort.InsertionSort(ref array);
            Sort.MergeSort(array);
			Console.WriteLine("После сортировки: " + string.Join(" ", array));
		}
        static int[] GetArray(int count, int maxValue)
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
