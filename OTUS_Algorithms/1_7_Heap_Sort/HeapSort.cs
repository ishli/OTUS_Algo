using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_7_Heap_Sort
{
	public class HeapSort : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			for (int root = array.Count / 2 - 1; root >= 0; root--)
			{
				Heapify(array, root, array.Count);
			}

			for (int i = array.Count - 1; i >= 0; i--)
			{
				Swap(array, 0, i);
				Heapify(array, 0, i);
			}
		}

		private void Heapify(List<int> array, int root, int size)
		{
			int l = 2 * root + 1;
			int r = 2 * root + 2;
			int x = root;
			if (l < size && array[l] > array[x])
			{
				x = l;
			}
			if (r < size && array[r] > array[x])
			{
				x = r;
			}

			if (x == root)
			{
				return;
			}

			Swap(array, x, root);
			Heapify(array, x, size);
		}

		private void Swap(List<int> array, int x, int y)
		{
			var t = array[x];
			array[x] = array[y];
			array[y] = t;
		}
	}
}
