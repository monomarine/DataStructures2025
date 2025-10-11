using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02._05_EventsWPF.Data
{
    public class NotificationService : IDisposable
    {
        private List<Order> _orders = new();
        private string _logFile = "logs.txt";

        public event EventHandler<OrderEventArgs>? UpdateData;
        protected virtual void OnUpdateData(OrderEventArgs e)
        {
            UpdateData?.Invoke(this, e);
        }

        public void AddOrder(params Order[] orders)
        {
            foreach(var o in orders)
            {
                o.Purchased += OrderPaid;
                _orders.Add(o);
            }
        }
        private void CleanPublishers()
        {
            foreach (var o in _orders)
                o.Purchased -= OrderPaid;

            _orders.Clear() ;
        }

        public void OrderPaid(object? send, OrderEventArgs e)
        {
            if (send is Order)
            {
                var order = (Order)send;
                string orderInfo = $"оплата от заказчика {order.Client} по заказу номер {order.Id} на сумму {e.Summ}";
                OnUpdateData(new OrderEventArgs($"оплата от заказчика {order.Client}", e.Summ));
                File.AppendAllText(_logFile, $"\n{e.TimeStamp}\t{orderInfo}");
            }
        }
         

        public void Dispose()
        {
            CleanPublishers();
        }
    }
}
