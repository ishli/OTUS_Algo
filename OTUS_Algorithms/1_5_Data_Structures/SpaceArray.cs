using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public class SpaceArray<T> : IArray<T>
	{
		private T[][] _array = new T[1][];
		private int currentMaxSize = 5;
		private int currentLastElementIndex = 0;
		private const double factor = 1.5;

		public SpaceArray()
		{
			_array[0] = new T[5];
		}

		public void Add(T t)
		{
			Resize();
			var rowAndIndex = GetRowAndColumnForIndex(currentLastElementIndex);
			_array[rowAndIndex.Key][rowAndIndex.Value] = t;

			currentLastElementIndex++;
		}

		public void Add(T t, int index)
		{
			Resize();
			MoveElementsInArrayToRight(index);
			var rowAndIndex = GetRowAndColumnForIndex(index);
			_array[rowAndIndex.Key][rowAndIndex.Value] = t;
			currentLastElementIndex++;
		}

		public T Get(int index)
		{
			var currentRows = _array.GetLength(0);

			for (int i = 0; i < currentRows; i++)
			{
				var columns = _array[i].Length;
				if (index < columns)
				{
					return _array[i][index];
				}
				else
				{
					index -= columns;
				}
			}

			throw new IndexOutOfRangeException();
		}

		private KeyValuePair<int, int> GetRowAndColumnForIndex(int index)
		{
			var currentRows = _array.GetLength(0);

			for (int i = 0; i < currentRows; i++)
			{
				var columns = _array[i].Length;
				if (index < columns)
				{
					return new KeyValuePair<int, int>(i, index);
				}
				else
				{
					index -= columns;
				}
			}

			throw new IndexOutOfRangeException();
		}

		public int Length()
		{
			return currentLastElementIndex;
		}

		public T Remove(int index)
		{
			var result = Get(index); ;

			MoveElementsInArrayToLeft(index);

			currentLastElementIndex--;
			return result;
		}

		private void Resize()
		{
			// считаем, что лишь увеличиваем array
			if (currentLastElementIndex == currentMaxSize)
			{
				var currentRows = _array.GetLength(0);
				var newArray = new T[currentRows + 1][];

				for (int i = 0; i < currentRows; i++)
				{
					var columns = _array[i].Length;
					newArray[i] = new T[columns];
					for (int j = 0; j < columns; j++)
					{
						newArray[i][j] = _array[i][j];
					}
				}
				var rnd = new Random();
				var c = rnd.Next(2, 8);
				newArray[currentRows] = new T[c];
				currentMaxSize += c;
				_array = newArray;
			}
		}

		private void MoveElementsInArrayToLeft(int index)
		{
			if (index == 0)
			{
				var currentRows = _array.GetLength(0);

				// идем с начала
				for (int i = 0; i < currentRows; i++)
				{
					var columns = _array[i].Length;
					for (int j = 0; j < columns - 1; j++)
					{
						_array[i][j] = _array[i][j + 1];
					}

					// не последняя строка
					if (i != currentRows - 1)
					{
						_array[i][columns - 1] = _array[i + 1][0];
					}
					else
					{
						// обнуляем последний элемент
						_array[i][columns - 1] = default(T);
					}
				}
			}
			else
			{
				var currentRows = _array.GetLength(0);
				var tempIndex = 0;

				// идем с начала
				for (int i = 0; i < currentRows; i++)
				{
					var columns = _array[i].Length;
					for (int j = 0; j < columns - 1; j++)
					{
						tempIndex++;
						if (tempIndex > index)
						{
							_array[i][j] = _array[i][j + 1];
						}
					}

					// не последняя строка
					if (i != currentRows - 1)
					{
						tempIndex++;
						if (tempIndex >= index)
						{
							_array[i][columns - 1] = _array[i + 1][0];
						}
					}
					else
					{
						// обнуляем последний элемент
						_array[i][columns - 1] = default(T);
					}
				}
			}
		}

		private void MoveElementsInArrayToRight(int index)
		{
			if (index == 0)
			{
				var currentRows = _array.GetLength(0);

				// идем с конца
				for (int i = currentRows - 1; i >= 0; i--)
				{
					var columns = _array[i].Length;

					for (int j = columns - 1; j >= 1; j--)
					{
						_array[i][j] = _array[i][j - 1];
					}

					// не первая строка
					if (i != 0)
					{
						var columnsOfPreviuosRow = _array[i - 1].Length;
						_array[i][0] = _array[i - 1][columnsOfPreviuosRow - 1];
					}
				}
			}
			else
			{
				var currentRows = _array.GetLength(0);
				var t = GetRowAndColumnForIndex(index);

				// идем с конца
				for (int i = currentRows - 1; i >= 0; i--)
				{
					var columns = _array[i].Length;

					// последний элемент в строке;
					var temp = _array[i][columns - 1];
					for (int j = columns - 1; j >= 1; j--)
					{
						//tempIndex++;
						if (i == t.Key && j == t.Value)
						{
							return;
						}
						_array[i][j] = _array[i][j - 1];
					}

					// не первая строка
					if (i != 0)
					{
						var columnsOfPreviuosRow = _array[i - 1].Length;

						if ((i - 1) == t.Key && (columnsOfPreviuosRow - 1) == t.Value)
						{
							return;
						}

						_array[i][0] = _array[i - 1][columnsOfPreviuosRow - 1];
					}
				}
			}
		}
	}
}
