using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public class InsertionSort : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			for (int i = 0; i < array.Count; i++)
			{
				int j = i - 1;

				while (j >= 0 && array[j] > array[j + 1])
				{
					Utils.Swap(array, j, j + 1);
					j--;
				}
			}
		}
	}
}
