using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._05_EventsWPF.Data
{
    public class OrderDisplayService : IDisposable
    {
        private List<Order> _orders = new();

        public event EventHandler<OrderEventArgs>? UpdateData;

        protected virtual void OnUpdateData(OrderEventArgs e)
        {
            UpdateData?.Invoke(this, e);
        }

        public void AddOrder(params Order[] orders)
        {
            foreach (var o in orders)
            {
                o.Purchased += DisplayOrderInfo;
                _orders.Add(o);
            }
        }

        private void DisplayOrderInfo(object? sender, OrderEventArgs e)
        {
            if (sender is Order order)
            {
                string displayMessage = $"оплата от заказчика {order.Client} по заказу номер {order.Id} на сумму {e.Summ}";
                OnUpdateData(new OrderEventArgs(displayMessage, e.Summ));
            }
        }

        private void CleanPublishers()
        {
            foreach (var o in _orders)
                o.Purchased -= DisplayOrderInfo;

            _orders.Clear();
        }

        public void Dispose()
        {
            CleanPublishers();
        }
    }
}
