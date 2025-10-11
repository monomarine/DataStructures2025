namespace _02._05_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(1, "Иванов ИИ");
            Order order2 = new Order(2, "Петров ПП");

            NotificationService service = new();

            service.AddOrder(order1);
            service.AddOrder(order2);
            Thread.Sleep(2000);
            order1.PaidOrder(1000);

        }
    }
}
