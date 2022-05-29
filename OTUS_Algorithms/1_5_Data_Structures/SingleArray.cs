using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public class SingleArray<T> : IArray<T>
	{
		private T[] _array = new T[0];

		public void Add(T t)
		{
			var newArray = new T[_array.Length + 1];
			Array.Copy(_array, newArray, _array.Length);
			newArray[_array.Length] = t;
			_array = newArray;
		}

		public void Add(T t, int index)
		{
			var newArray = new T[_array.Length + 1];
			if (index == 0)
			{
				_array.CopyTo(newArray, index + 1);
				newArray[index] = t;
			}
			else
			{
				Array.Copy(_array, 0, newArray, 0, index);
				newArray[index] = t;
				Array.Copy(_array, index, newArray, index + 1, _array.Length - index);
			}

			_array = newArray;
		}

		public T Get(int index)
		{
			return _array[index];
		}

		public int Length()
		{
			return _array.Length;
		}

		public T Remove(int index)
		{
			var result = _array[index];
			var newArray = new T[_array.Length - 1];

			if (index == 0)
			{
				Array.Copy(_array, index + 1, newArray, index, _array.Length - 1);
			}
			else
			{
				Array.Copy(_array, 0, newArray, 0, index);
				Array.Copy(_array, index + 1, newArray, index, _array.Length - index - 1);
			}
			_array = newArray;

			return result;
		}
	}
}
