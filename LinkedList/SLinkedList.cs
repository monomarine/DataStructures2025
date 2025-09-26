using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
#pragma warning disable
    internal class SLinkedList : IEnumerable<string>
    {
        private Node _head;
        private Node _tail;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _head == null;

        public SLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        /*
         * функционал:
         * 
         * получить первый элемент !
         * получить последний элемент - сам
         * 
         * удалить первый элемент - сам
         * удалить последний элемент !
         * удалить элемент по его данным - сам
         * 
         * проверить наличие элемента !
         * перевернуть!
         * 
         */

        public string GetLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пуст");
            return _tail.Data;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пуст");

            if (_count == 1)
            {
                Clear();
            }
            else
            {
                _head = _head.Next;
                _count--;
            }
        }

        public bool Remove(string data)
        {
            if (IsEmpty || data == null)
                return false;

            if (_head.Data == data)
            {
                RemoveFirst();
                return true;
            }

            Node current = _head;
            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;
            }

            if (current.Next != null && current.Next.Data == data)
            {
                if (current.Next == _tail)
                {
                    _tail = current;
                }

                current.Next = current.Next.Next;
                _count--;
                return true;
            }

            return false;
        }

        public void Reverse()
        {
            if (Count <= 1)
                throw new ArgumentException("количество элементов не достаточно для реверса");

            Node prev = null;
            Node current = _head;
            Node next = null;

            _tail = _head;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            _head = prev;
        }
        public void RemoveLast()
        {
            if (IsEmpty)
                throw new ArgumentNullException("список пуст");
            else if (Count == 1)
                Clear();
            else
            {
                Node current = _head;
                while (current.Next != _tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                _tail = current;

                _count--;
            }


        }

        public string GetFirst()
        {
            if (IsEmpty)
                throw new ArgumentNullException("список пуст");
            else
                return _head.Data;
        }

        public bool Contains(string item)
        {
            if (IsEmpty)
                throw new ArgumentNullException("список пуст");
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    if (current.Data == item)
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
        }
        public void AddFirst(string text)
        {
            if (text == null)
                throw new ArgumentException("данные пустые");
            Node newNode = new Node(text);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
            _count++;
        }

        public void AddLast(string text)
        {
            if (text == null)
                throw new ArgumentException("данные пустые");
            Node newNode = new Node(text);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public void InsertAfter(string existingText, string text)
        {
            if (existingText == null || text == null)
                throw new ArgumentException("данные не могут быть пустые");
            Node newNode = new Node(text);
            Node current = _head;
            while (current.Next != null)
            {
                if (current.Data == existingText)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    if (current == _tail)
                        _tail = current;
                }
                current = current.Next;
            }

            _count++;
        }

        public IEnumerator<string> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {

                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
    }
}
