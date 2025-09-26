using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
#pragma warning disable
    internal class SStack: IEnumerable<string>
    {
        private Node _top;
        private int _count;

        public int Count => _count;  
        public bool IsEmpty => _top == null; 

        public SStack()
        {
            _top = null;
            _count = 0;
        }

        public void Push(string text)
        {
            if (text == null)
                throw new ArgumentException("Данные пустые");
            Node node = new(text);
            node.Next = _top;
            _top = node;
            _count++;
        }

        public string Peek()
        {
            if (_top == null)
                throw new ArgumentNullException("Пустой список");
            return _top.Data;
        }

        public string Pop()
        {
            if (IsEmpty)
                throw new ArgumentNullException("Пустой список");
            string data = _top.Data;
            _top = _top.Next;
            _count--;
            return data;
        }

        public void Clear()
        {
            _top = null;
            _count = 0;
        }

		public IEnumerator<string> GetEnumerator()
		{
            Node current = _top;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
