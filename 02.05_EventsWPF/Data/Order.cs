using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._05_EventsWPF
{
    public enum OrderStatus { New, Paid }
    public class Order
    {
        public event EventHandler<OrderEventArgs>? Purchased; //событие
        //внутренний метод для генерации события с передачей
        //ссылки на заказ и аргументами e
        protected virtual void OnPurshared(OrderEventArgs e) =>
            Purchased?.Invoke(this, e);
        public int Id { get; set; }
        public OrderStatus Status { get; private set; }
        public string Client { get; }
        public Order(int id, string client)
        {
            Status = OrderStatus.New;
            Client = client;
            Id = id;
        }
        public void PaidOrder(decimal summ)
        {
            this.Status = OrderStatus.Paid;
            OnPurshared(new OrderEventArgs("заказ оплачен", summ));
        }

        public override string ToString()
        {
            return $"{Id} : {Client}";
        }
    }
}
