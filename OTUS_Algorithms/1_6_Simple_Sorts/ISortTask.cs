using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public interface ISortTask
	{
		void Sort(List<int> array) { }

		bool IsSorted(List<int> array)
		{
			for (int i = 1; i < array.Count; i++)
			{
				if (array[i] < array[i - 1])
				{
					return false;
				}
			}

			return true;
		}

	}
}
