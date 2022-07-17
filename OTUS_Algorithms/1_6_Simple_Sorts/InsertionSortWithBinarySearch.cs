using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public class InsertionSortWithBinarySearch : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}


			int loc, selected;

			for (var i = 1; i < array.Count; ++i)
			{
				var j = i - 1;
				selected = array[i];

				// find location where selected should be inseretd
				loc = BinarySearch(array, selected, 0, j);

				// Move all elements after location to create space
				while (j >= loc)
				{
					array[j + 1] = array[j];
					j--;
				}
				array[j + 1] = selected;
			}
		}

		private int BinarySearch(List<int> arr, int item, int low, int high)
		{
			while (low <= high)
			{
				int mid = low + (high - low) / 2;
				if (item == arr[mid])
					return mid + 1;
				else if (item > arr[mid])
					low = mid + 1;
				else
					high = mid - 1;
			}

			return low;
		}
	}
}
