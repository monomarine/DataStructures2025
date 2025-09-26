using System.Collections;

namespace LinkedList
{
#pragma warning disable
	internal class SLinkedList<T> : IEnumerable<T>
	{
		private Node<T> _head;
		private Node<T> _tail;
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
         
		public string GetFirst()
		{
			return _head == null ? null : _head.Data.ToString();
		}

		public string GetLast()
		{
			return _tail == null ? null : _tail.Data.ToString();
		}

		public bool Contains(T data)
		{
			if (IsEmpty)
				return false;

			Node<T> current = _head;

			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}

		public void RemoveFirst()
		{
			if (IsEmpty)
				throw new ArgumentOutOfRangeException("список пуст");

			Node<T> nextHead = _head.Next;
			_head.Next = null;
			_head = nextHead;

			_count--;
		}

		public void RemoveLast()
		{
			if (IsEmpty)
				throw new ArgumentOutOfRangeException("список пуст");

			Node<T> current = _head;

			while (current.Next.Next != null)
				current = current.Next;

			current.Next.Next = null;
			current.Next = null;
			_tail = current;

			_count--;
		}

		public void Remove(T data)
		{
			if (IsEmpty)
				throw new ArgumentOutOfRangeException("список пуст");

			Node<T> current = _head;

			while (current != null)
			{
				if (current.Next != null && current.Next.Data.Equals(data))
				{
					if (current.Next.Next != null)
					{
						current.Next = current.Next.Next;
					}
					else
					{
						current.Next = null;
						_tail = current;
					}

					_count--;
					break;
				}
				current = current.Next;
			}
		}

		public void Clear()
		{
			Node<T> current = _head;

			while (current != null)
			{
				current.Next = null;
			}

			_head = null;
			_tail = null;
			_count = 0;
		}

		public void Reverse()
		{
			Node<T> current = _head;

			Node<T> previous = null;
			Node<T> next = null;

			_tail = _head;

			while (current != null)
			{
				next = current.Next;
				current.Next = previous;
				previous = current;
				current = next;
			}

			_head = previous;

			Node<T> head = _head;
			_tail = head;
			_head = _tail;
		}

		public void AddFirst(T data)
		{
			if (data == null)
				throw new ArgumentException("данные пустые");

			Node<T> node = new(data);

			if (IsEmpty)
				_tail = node;
			node.Next = _head;
			_head = node;

			_count++;
		}

		public void InsertAfter(T existing, T data)
		{
			if (existing == null || data == null)
				throw new ArgumentException("данные пустые");
			if (IsEmpty)
			{
				AddFirst(data);
				return;
			}

			Node<T> node = new(data);
			Node<T> current = _head;

			while (current.Next != null)
			{
				if (current.Data.Equals(existing))
				{
					node.Next = current.Next;
					current.Next = node;
					_count++;
					break;
				}
				current = current.Next;
			}

		}

		public void AddLast(T data)
		{
			if (data == null)
				throw new ArgumentException("данные пустые");

			Node<T> node = new Node<T>(data);

			if (IsEmpty)
				_head = node;

			Node<T> prevTail = _tail;
			prevTail.Next = node;

			_tail = node;

			_count++;
		}

		public IEnumerator<T> GetEnumerator()
		{
			Node<T> current = _head;
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
	}
}