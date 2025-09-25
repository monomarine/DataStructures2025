namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SStack stack = new SStack();
                stack.Push("Москва");
                stack.Push("Екатеринбург");
                stack.Push("Оренбург");

                Console.WriteLine("Верхний элемент: " + stack.Peek()); 
                Console.WriteLine("Удалённый элемент: " + stack.Pop()); 
                Console.WriteLine("Верхний элемент теперь: " + stack.Peek()); 
                Console.WriteLine("Размер стека: " + stack.Count); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
