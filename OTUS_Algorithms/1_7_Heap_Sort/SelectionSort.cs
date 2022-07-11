using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_7_Heap_Sort
{
	internal class SelectionSort
	{
		private void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			int x = FindMax(array, array.Count);

			for (int i = array.Count -1 ; i > 0; i--)
			{
				Swap(array, x, i);
				x = FindMax(array, i);
			}
		}

		private void Swap(List<int> array, int x, int y)
		{
			var t = array[x];
			array[x] = array[y];
			array[y] = t;
		}

		private int FindMax(List<int> array, int length)
		{
			var x = 0;
			for (int i = 1; i < length; i++)
			{
				if (array[i] > array[x])
				{
					x = i;
				}
			}

			return x;
		}


	}
}
