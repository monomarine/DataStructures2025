using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
#pragma warning disable
    internal class SStack
    {
        private Node _top;
        private int _count;

        public SStack()
        {
            _top = null;
            _count = 0;
        }
        public bool IsEmpty => _top == null;
        public int Count => _count;

        /*
         * добавление элемента в стек !
         * извлечение элемента из стека !
         * просмотр верхнего элемента - самостоятельно +
         * проверка на пустоту !
         * вернуть размер стека!
         * очистить стека !
         * 
         */

        // верхний эл просмотр
        public string Peek()
        {
            if (IsEmpty)
                throw new ArgumentException("данные пусты");
            return _top.Data;
        }

        public void Push(string text)
        {
            if (text == null)
                throw new ArgumentNullException("записываемые данные не должны быть пусты");
            Node newNode = new Node(text);
            newNode.Next = _top;
            _top = newNode;
            _count++;
        }
        public string Pop()
        {
            if (IsEmpty)
                throw new ArgumentNullException("список пуст");
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
    }
}
