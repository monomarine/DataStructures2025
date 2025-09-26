using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Sort
    {
        public static long StepCount { get; private set; } = 0;

        public static void ResetStepCount()
        {
            StepCount = 0;
        }

        public static void BubbleSort(ref int[] data)
        {
            ResetStepCount();
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    StepCount++;
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                        StepCount += 3;
                    }
                }
            }
        }

        public static void SelectionSort(ref int[] data)
        {
            ResetStepCount();
            for (int i = 0; i < data.Length - 1; i++)
            {
                int minInd = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    StepCount++;
                    if (data[j] < data[minInd])
                    {
                        minInd = j;
                        StepCount++;
                    }
                }
                StepCount++;
                if (minInd != i)
                {
                    int temp = data[i];
                    data[i] = data[minInd];
                    data[minInd] = temp;
                    StepCount += 3;
                }
            }
        }

        public static void InsertionSort(ref int[] data)
        {
            ResetStepCount();
            for (int i = 1; i < data.Length; i++)
            {
                int key = data[i];
                int j = i - 1;
                StepCount += 2;

                StepCount++;
                while (j >= 0 && data[j] > key)
                {
                    data[j + 1] = data[j];
                    j--;
                    StepCount += 3;
                }
                data[j + 1] = key;
                StepCount++;
            }
        }

        #region QuickSort
        public static void QuickSort(int[] data)
        {
            ResetStepCount();
            QuickSortReqursive(data, 0, data.Length - 1);
        }

        private static void QuickSortReqursive(int[] data, int start, int end)
        {
            StepCount++;
            if (start < end)
            {
                int pivot = GetPivotIndex(data, start, end);
                QuickSortReqursive(data, start, pivot - 1);
                QuickSortReqursive(data, pivot + 1, end);
            }
        }

        private static int GetPivotIndex(int[] data, int start, int end)
        {
            int middle = start + (end - start) / 2;
            int pivotValue = data[middle];
            Swap(data, middle, end);
            StepCount += 4; 

            int i = start;
            for (int j = start; j < end; j++)
            {
                StepCount++;
                if (data[j] <= pivotValue)
                {
                    Swap(data, i, j);
                    i++;
                    StepCount += 3;
                }
                StepCount++;
            }
            Swap(data, i, end);
            StepCount++;
            return i;
        }

        private static void Swap(int[] data, int pos1, int pos2)
        {
            int temp = data[pos1];
            data[pos1] = data[pos2];
            data[pos2] = temp;
            StepCount += 3;
        }
        #endregion

        #region MergeSort
        public static void MergeSort(int[] data)
        {
            ResetStepCount();
            if (data.Length == 0) return;
            int[] temp = new int[data.Length];
            MergeSortRecursive(data, 0, data.Length - 1, temp);
        }

        private static void MergeSortRecursive(int[] data, int start, int end, int[] temp)
        {
            StepCount++;
            if (start < end)
            {
                int middle = start + (end - start) / 2;
                StepCount++;

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
            StepCount += 3;

            while (i <= middle && j <= end)
            {
                StepCount += 2;
                if (data[i] <= data[j])
                {
                    temp[k] = data[i];
                    i++;
                    StepCount += 2;
                }
                else
                {
                    temp[k] = data[j];
                    j++;
                    StepCount += 2;
                }
                k++;
                StepCount++;
            }

            while (i <= middle)
            {
                temp[k] = data[i];
                i++;
                k++;
                StepCount += 3;
            }

            while (j <= end)
            {
                temp[k] = data[j];
                j++;
                k++;
                StepCount += 3;
            }

            for (k = start; k <= end; k++)
            {
                data[k] = temp[k];
                StepCount += 2; 
            }
        }
        #endregion
    }
}