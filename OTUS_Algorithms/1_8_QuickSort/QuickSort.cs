using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_8_QuickSort
{
	public class QuickSort : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			Sort(0, array.Count - 1);
			//SortIterative(0, array.Count - 1);

			void Sort(int l, int r)
			{
				if (l >= r)
				{
					return;
				}
				int x = Split(l, r);
				Sort(l, x - 1);
				Sort(x + 1, r);
			}

			void SortIterative(int l, int r)
			{
				int[] stack = new int[r - l + 1];

				int top = -1;

				stack[++top] = l;
				stack[++top] = r;

				while (top >= 0)
				{
					r = stack[top--];
					l = stack[top--];

					int p = Split(l, r);

					if (p - 1 > l)
					{
						stack[++top] = l;
						stack[++top] = p - 1;
					}

					if (p + 1 < r)
					{
						stack[++top] = p + 1;
						stack[++top] = r;
					}
				}
			}

			int Split(int l, int r)
			{
				int p = array[r];
				int m = l - 1;
				for (int i = l; i <= r; i++)
				{
					if (array[i] <= p)
					{
						m++;
						Swap(m, i);
					}
				}

				return m;
			}

			void Swap(int i, int j)
			{
				int temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			}
		}
	}
}
