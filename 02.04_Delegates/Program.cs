namespace _02._04_Delegates
{
    public delegate bool FilterDelegate(int x);
    public delegate bool StringFilterDelegate(string x);
    internal class Program
    {
        //переписать код для коллекции строк и произвести фильтрацию строк (вывести в результат только
        //те строки, в которых нет спецсимволов)
        static void Main(string[] args)
        {
            List<int> numbers = new() { 4, 8, 2, 8, 5, 98, 8, 5, };
            var res1 = Filter(numbers, n => n % 2 == 0);
            var res2 = Filter(numbers, n => n > 10);

            List<string> strings = new()
            {
                "hello"
            };

            var stringResult = FilterStrings(strings, s => !ContainsSpecialCharacters(s));
            Console.WriteLine("Строки без специальных символов:");
            foreach (var r in stringResult)
                Console.WriteLine(r);


        }

        public static List<int> Filter(List<int> data, FilterDelegate delegat)
        {
            var result = new List<int>();
            foreach (int d in data)
            {
                if (delegat(d))
                    result.Add(d);
            }
            return result;
        }

        public static List<string> FilterStrings(List<string> data, StringFilterDelegate delegat)
        {
            var result = new List<string>();
            foreach (string d in data)
            {
                if (delegat(d))
                {
                    result.Add(d);
                }
            }
            return result;
        }
        public static bool ContainsSpecialCharacters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
