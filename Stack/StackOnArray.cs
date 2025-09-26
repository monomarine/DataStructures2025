using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	internal class StackOnArray: IEnumerable<string>
	{
		private string[] _data;
		private int _top;
		private int _capacity;

		public StackOnArray(int capacity = 10)
		{
			_capacity = capacity;
			_data = new string[capacity];
			_top = -1;
		}

		public bool IsEmpty => _top == -1;
		public int Count => _top + 1;

		public void Push(string value)
		{
			if (value == null)
				throw new ArgumentException("Данные пустые");
			if (_top >= _data.Length - 1)
				throw new StackOverflowException();
			_data[++_top] = value;

		}

		public string Pop()
		{
			if (IsEmpty)
				throw new ArgumentNullException("Данные отсутсвуют");

			return _data[_top--];
		}

		public string Peek()
		{
			if (IsEmpty)
				throw new ArgumentNullException("Данные отсутсвуют");

			return _data[_top];
		}

		public void Clear()
		{
			_top = -1;
		}

		public IEnumerator<string> GetEnumerator()
		{
			foreach (string item in _data)
			{
				if (item != null) yield return item;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
