using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public class MatrixArray<T> : IArray<T>
	{
		private T[,] _array = new T[1, columns];
		private const int columns = 5;

		private int currentLastElementIndex = 0;
		private const double factor = 1.5;

		public void Add(T t)
		{
			Resize();
			_array[GetRow(currentLastElementIndex), GetColumn(currentLastElementIndex)] = t;
			currentLastElementIndex++;
		}

		public void Add(T t, int index)
		{
			Resize();

			if (index == 0)
			{
				Array.Copy(_array, index, _array, index + 1, currentLastElementIndex);
				_array[GetRow(index), GetColumn(index)] = t;
			}
			else
			{
				Array.Copy(_array, index, _array, index + 1, currentLastElementIndex - index);
				_array[GetRow(index), GetColumn(index)] = t;
			}

			currentLastElementIndex++;
		}

		public T Get(int index)
		{
			return _array[index / columns, index % columns];
		}

		public int Length()
		{
			return currentLastElementIndex;
		}

		public T Remove(int index)
		{
			var result = _array[GetRow(index), GetColumn(index)];

			Array.Copy(_array, index + 1, _array, index, currentLastElementIndex - index - 1);

			currentLastElementIndex--;
			return result;
		}

		private int GetRow(int index)
		{
			return index / columns;
		}

		private int GetColumn(int index)
		{
			return index % columns;
		}

		private void Resize()
		{
			var currentRows = _array.GetLength(0);
			// считаем, что лишь увеличиваем array
			if (currentLastElementIndex == currentRows * columns)
			{
				var newArray = new T[currentRows + 1, columns];
				for (int i = 0; i < currentRows; i++)
				{
					for (int j = 0; j < columns; j++)
					{
						newArray[i, j] = _array[i, j];
					}
				}
				_array = newArray;
			}
		}
	}
}
