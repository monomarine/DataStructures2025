using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._05_Events
{
#pragma warning disable
    internal class NotificationService : IDisposable
    {
        private List<Order> _orders = new();
        private string _logFile = "logs.txt";
        
        public void AddOrder(Order order)
        {
            order.Purchased += OrderPaid;
            _orders.Add(order);
        }
        private void CleanPublishers()
        {
            foreach (var o in _orders)
                o.Purchased -= OrderPaid;

            _orders = null;
        }

        public void OrderPaid(object send, OrderEventArgs e)
        {
            if(send is  Order)
            {
                var order = (Order)send;
                string orderInfo = $"оплата от заказчика {order.Client} по заказу номер {order.Id} на сумму {e.Summ}";
                Console.WriteLine(orderInfo);
                File.AppendAllText(_logFile, $"{e.TimeStamp}\t{orderInfo}");
            }


        }

        public void Dispose()
        {
            CleanPublishers();
        }
    }
}
