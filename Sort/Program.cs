using System.Diagnostics;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
                TestAllAlgorithms(100);
                TestAllAlgorithms(1000);
                TestAllAlgorithms(300000);

            static void TestAllAlgorithms(int size)
            {
                int[] array = GetArray(size);
                Console.WriteLine($" Размер массива: {size}");

                int[] copy = (int[])array.Clone();
                Stopwatch timer = new Stopwatch();
                Sort.ResetStepCount();
                timer.Start();
                Sort.BubbleSort(ref copy);
                timer.Stop();
                Console.WriteLine($"BubbleSort: шаги = {Sort.StepCount}, время = {timer.ElapsedMilliseconds} мс");

                copy = (int[])array.Clone();
                Sort.ResetStepCount();
                timer.Restart();
                Sort.SelectionSort(ref copy);
                timer.Stop();
                Console.WriteLine($"SelectionSort: шаги = {Sort.StepCount}, время = {timer.ElapsedMilliseconds} мс");

                copy = (int[])array.Clone();
                Sort.ResetStepCount();
                timer.Restart();
                Sort.InsertionSort(ref copy);
                timer.Stop();
                Console.WriteLine($"InsertionSort: шаги = {Sort.StepCount}, время = {timer.ElapsedMilliseconds} мс");

                copy = (int[])array.Clone();
                Sort.ResetStepCount();
                timer.Restart();
                Sort.QuickSort(copy);
                timer.Stop();
                Console.WriteLine($"QuickSort: шаги = {Sort.StepCount}, время = {timer.ElapsedMilliseconds} мс");

                copy = (int[])array.Clone();
                Sort.ResetStepCount();
                timer.Restart();
                Sort.MergeSort(copy);
                timer.Stop();
                Console.WriteLine($"MergeSort: шаги = {Sort.StepCount}, время = {timer.ElapsedMilliseconds} мс");
            }

           int[] array = GetArray(10000);
           // Console.WriteLine("до сортировки:");

            /*foreach (int i in array) 
                Console.Write(i+" ");*/

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Sort.QuickSort( array);
            timer.Stop();

          //  Console.WriteLine("\nпосле сортировки:");

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