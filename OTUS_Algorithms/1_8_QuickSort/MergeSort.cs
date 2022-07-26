using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_8_QuickSort
{
	public class MergeSort : ISortTask
	{

		public void Sort(List<int> array)
		{

			if (array.Count <= 1)
			{
				return;
			}

			Sort(0, array.Count - 1);

			void Sort(int l, int r)
			{
				if (l >= r)
				{
					return;
				}
				int m = (l + r) / 2;
				Sort(l, m);
				Sort(m + 1, r);
				Merge(l, m, r);
			}

			void Merge(int l, int m, int r)
			{

				int n1 = m - l + 1;
				int n2 = r - m;

				int[] L = new int[n1];
				int[] R = new int[n2];
				int i, j;

				for (i = 0; i < n1; ++i)
					L[i] = array[l + i];
				for (j = 0; j < n2; ++j)
					R[j] = array[m + 1 + j];
				i = 0;
				j = 0;

				int k = l;
				while (i < n1 && j < n2)
				{
					if (L[i] <= R[j])
					{
						array[k++] = L[i++];
					}
					else
					{
						array[k++] = R[j++];
					}
				}

				while (i < n1)
				{
					array[k++] = L[i++];

				}

				while (j < n2)
				{
					array[k++] = R[j++];
				}
			}
		}
	}
}
