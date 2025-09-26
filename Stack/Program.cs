namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackOnArray stack = new();
            stack.Push("Первый");
            stack.Push("Второй");
            stack.Push("Третий");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"=Получаем первый => {stack.Peek()}=");
            Console.WriteLine($"=Вытягиваем первый => {stack.Pop()}=");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=Очищаем=");
            stack.Clear();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}