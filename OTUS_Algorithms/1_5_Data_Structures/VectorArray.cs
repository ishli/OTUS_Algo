using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public class VectorArray<T> : IArray<T>
	{
		private T[] _array = new T[0];
		private int currentLastElementIndex = 0;
		private const int newSectionSize = 10;

		public void Add(T t)
		{
			Resize();
			_array[currentLastElementIndex++] = t;
		}

		public void Add(T t, int index)
		{
			Resize();

			Array.Copy(_array, index, _array, index + 1, currentLastElementIndex - index);
			_array[index] = t;

			currentLastElementIndex++;
		}

		public T Get(int index)
		{
			return _array[index];
		}

		public int Length()
		{
			return currentLastElementIndex;
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
			currentLastElementIndex--;
			return result;
		}

		private void Resize()
		{
			if (currentLastElementIndex == _array.Length)
			{
				var newArray = new T[_array.Length + newSectionSize];
				Array.Copy(_array, newArray, _array.Length);
				_array = newArray;
			}
		}
	}
}
