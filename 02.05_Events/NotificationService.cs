using System;
using System.Collections.Generic;
using _02._05_Events;


namespace _02._05_EventsWPF
{
    internal class NotificationService : IDisposable
    {
        private List<Order> _orders = new();
        private readonly Logger _logger;

        public event EventHandler<OrderEventArgs>? UpdateData;

        public NotificationService()
        {
            _logger = new Logger();
        }

        public void AddOrder(params Order[] orders)
        {
            foreach (var order in orders)
            {
                order.Purchased += OrderPaid;
                _orders.Add(order);
            }
        }

        private void CleanPublishers()
        {
            foreach (var o in _orders)
                o.Purchased -= OrderPaid;

            _orders.Clear();
        }

        private void OrderPaid(object sender, OrderEventArgs e)
        {
            if (sender is Order order)
            {
                string message = $"Оплата от заказчика {order.Client} по заказу №{order.Id} на сумму {e.Summ}";

                _logger.Log(message);
                UpdateData?.Invoke(this, new OrderEventArgs(message, e.Summ));
            }
        }

        public void Dispose() => CleanPublishers();
    }
}
