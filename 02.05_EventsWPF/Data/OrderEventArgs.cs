using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._05_EventsWPF
{
    public class OrderEventArgs : EventArgs
    {
        public string Message { get; }
        public DateTime TimeStamp { get; }
        public decimal Summ { get; }

        public OrderEventArgs(string message, decimal summ)
        {
            Message = message;
            Summ = summ;
            TimeStamp = DateTime.UtcNow;
        }
    }
}
