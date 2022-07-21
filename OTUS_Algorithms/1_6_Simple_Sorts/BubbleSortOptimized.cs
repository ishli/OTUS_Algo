using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public class BubbleSortOptimized : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			bool swapped;

			for (int i = 0; i < array.Count; i++)
			{
				swapped = false;
				for (int j = 0; j < array.Count - 1; j++)
				{
					if (array[j] > array[j + 1])
					{
						Utils.Swap(array, j, j + 1);

						swapped = true;
					}
				}


				if (!swapped)
				{
					break;
				}
			}
		}
	}
}