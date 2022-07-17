using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	// use 4^k + 3*2^(k-1) + 1
	public class ShellSortSedgewick : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			int n = array.Count;

			var l = (int)(Math.Log2(n) / 2) + 1;
			var gaps = new List<int>(l);
			FillGaps(gaps, l, n - 1);
			var hIndex = gaps.Count - 1;
			var h = gaps[hIndex];

			while (h >= 1)
			{
				for (int i = h; i < n; i++)
				{
					for (int j = i; j >= h && array[j] < array[j - h]; j -= h)
					{
						Common.Swap(array, j, j - h);
					}
				}
				h = hIndex > 0 ? gaps[--hIndex] : 0;
			}
		}

		private void FillGaps(List<int> gaps, int l, int max)
		{
			gaps.Add(1);

			for (int i = 1; i < l; i++)
			{
				var t = (int)(Math.Pow(4, i) + 3 * Math.Pow(2, i - 1) + 1);
				if (t <= max) { }
				gaps.Add(t);
			}
		}
	}
}

