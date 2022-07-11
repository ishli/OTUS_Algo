using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public class InsertionSort
	{
		private void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			for (int i = 0; i < array.Count - 1; i++)
			{
				int j = i - 1;

				while (j >= 0 && array[j] > array[j + 1])
				{
					Swap(array, j, j + 1);
					j--;
				}

			}
		}

		private void Swap(List<int> array, int x, int y)
		{
			var t = array[x];
			array[x] = array[y];
			array[y] = t;
		}
	}
}
