using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _1_6_Simple_Sorts
{
	public class ShellSortKnuth : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			int n = array.Count;

			int h = 1;
			while (h < n / 3)
			{
				h = 3 * h + 1;
			}

			while (h >= 1)
			{
				for (int i = h; i < n; i++)
				{
					for (int j = i; j >= h && array[j] < array[j - h]; j -= h)
					{
						Utils.Swap(array, j, j - h);
					}
				}
				h /= 3;
			}
		}
	}
}
