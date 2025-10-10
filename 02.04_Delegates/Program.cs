using System;
using System.Collections.Generic;

namespace _02._04_Delegates
{
    public delegate bool FilterDelegate(string x);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new() { "Hello", "@World_", "123", "jcfj" };

            var filtered = Filter(words, s => IsAlphanumeric(s));

            foreach (var word in filtered)
            {
                Console.Write(word + " ");
            }
        }

        public static List<string> Filter(List<string> data, FilterDelegate delegat)
        {
            var result = new List<string>();
            foreach (string d in data)
            {
                if (delegat(d))
                    result.Add(d);
            }
            return result;
        }
        public static bool IsAlphanumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }
}