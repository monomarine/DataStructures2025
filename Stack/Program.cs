namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SStack linkedListStack = new SStack();
                linkedListStack.Push("Москва");
                linkedListStack.Push("Екатеринбург");
                linkedListStack.Push("Оренбург");

                Console.WriteLine("Peek: " + linkedListStack.Peek());
                Console.WriteLine("Pop: " + linkedListStack.Pop());
                Console.WriteLine("Peek: " + linkedListStack.Peek());

                StackOnArray arrayStack = new StackOnArray();
                arrayStack.Push("Самара");
                arrayStack.Push("Казань");

                Console.WriteLine("Peek: " + arrayStack.Peek());
                Console.WriteLine("Pop: " + arrayStack.Pop());
                Console.WriteLine("Peek: " + arrayStack.Peek());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }






        }
    }
}
