using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int N = 10000;
        int x = N - 1;
        int[] arr = new int[N];
        HashSet<int> hashSet = new HashSet<int>();

        for (int i = 0; i < N; i++)
        {
            arr[i] = i;
            hashSet.Add(i);
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();
        foreach (int i in arr)
        {
            if (i == x)
            {
                sw.Stop();
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("Linear:\t" +sw.ElapsedTicks);

        sw.Restart();
        hashSet.Contains(x);
        sw.Stop();
        Console.WriteLine("Hash:\t" + sw.ElapsedTicks);

        sw.Restart();
        IterativeBinarySearch(x, arr);
        sw.Stop();
        Console.WriteLine("Iteractive:\t" + sw.ElapsedTicks);

    }

    public static int IterativeBinarySearch(int key, params int[] values)
    {
        int left = 0;
        int right = values.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (values[middle] == key)
            {
                return middle;
            }
            else if (values[middle] > key)
                right = middle - 1;
            else
                left = middle + 1;
        }
        return -1;
    }
}