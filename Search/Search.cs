using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Search
{
    internal static class Search
    {
        public static int LinearSearch(int key, params int[] values)
        {
            int count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if(values[i] == key)
                    return i;
            }
            return -1;
        }

        public static int IterativeBinarySearch(int key, params int[] values)
        {
            return -1;
        }

        public static int RecursiveBinarySearch(int key, params int[] values)
        {
            return -1;
        }

        public static int InterpolateSearch(int key, params int[] values)
        {
            return -1;
        }
    }
}
