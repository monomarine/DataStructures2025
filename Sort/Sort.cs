using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Sort
    {
        public static void BubbleSort(ref int[] data)
        {
            int counter = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j+1])
                    {
                        int temp = data[j];
                        data[j] = data[j+1];
                        data[j+1] = temp;   
                    }
                    counter++;
                }
            }
			Console.WriteLine($"Сортировка пузырьком завершена за {counter} шагов");
		}

        public static void SelectionSort(ref int[] data)
        {
            int counter = 0;
            for (int i = 0; i < data.Length - 1; i++)
            { 
                int minInd = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[j] < data[minInd])
                    {
                        minInd = j;
                    }
                    counter++;
                }
                if (minInd != i)
                {
                    int temp = data[i];
                    data[i] = data[minInd];
                    data[minInd] = temp;
                }
            }
			Console.WriteLine($"Сортировка выбором завершена за {counter} шагов");
		}

        public static void InsertionSort(ref int[] data)
        {
            int counter = 0;
            for (int i = 1; i < data.Length; i++)
            { 
                int key = data[i];
                int j = i - 1;

                while (j >= 0 && data[j] > key)
                {
                    data[j + 1] = data[j];
                    j--;
                    counter++;
                }
                counter++;
                data[j + 1] = key;
            }
            Console.WriteLine($"Сортировка вставками завершена за {counter} шагов");
        }

		#region QuickSort
		private static void QuickSortRecursive(int[] data, int start, int end)
        { 
            if (start < end)
            {
                int pivot = GetPivotIndex(data, start, end);
                QuickSortRecursive(data, start, pivot - 1);
                QuickSortRecursive(data, pivot + 1, end);
            }
        }

        public static void QuickSort(int[] data) => QuickSortRecursive(data, 0, data.Length - 1);

        private static int GetPivotIndex(int[] data, int start, int end)
        {
            int middle = start + (start + end) / 2;
            int pivotValue = data[middle];
            Swap(data, middle, end);
            int i = start;
            for (int j = start; j < end; j++)
            {
                if (data[j] < pivotValue)
                {
                    Swap(data, i, j);
                    i++;
                }
            }
            Swap(data, i, end);
            return i;
        }

        private static void Swap(int[] data, int pos1, int pos2)
        {
            int temp = data[pos1];
            data[pos1] = data[pos2];
            data[pos2] = temp;
        }
		#endregion

		#region MergeSort
        
        public static void MergeSort(int[] data)
        {
            if (data.Length == 0) return;
            int[] temp = new int[data.Length];

            MergeSortRecursive(data, 0, data.Length - 1, temp);
        }

        private static void MergeSortRecursive(int[] data, int start, int end, int[] temp)
        {
            if (start < end)
            {
                int middle = start + (end - start) / 2;

                MergeSortRecursive(data, start, middle, temp);
                MergeSortRecursive(data, middle + 1, end, temp);

                Merge(data, start, middle, end, temp);
            }
        }

        private static void Merge(int[] data, int start, int middle, int end, int[] temp)
        {
            int i = start;
            int j = middle + 1;
            int k = start;

            while (i <= middle && j <= end)
            {
				if (data[i] <= data[j])
				{
					temp[k] = data[i];
					i++;
				}
                else
                {
                    temp[k] = data[j];
                    j++;
                }
                k++;
			}
            while (i <= middle)
            {
                temp[k] = data[i];
                i++;
                k++;
            }
            while (j < end)
            {
                temp[k] = data[j];
                j++;
                k++;
            }
            for (k = start;  k <= end; k++)
            {
                data[k] = temp[k];
            }
        }

		#endregion
	}
}
