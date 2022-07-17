using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	internal class ShellSort : ISortTask
	{
		public void Sort(List<int> array)
		{
			if (array.Count <= 1)
			{
				return;
			}

			for (int gap = array.Count / 2; gap > 0; gap /= 2)
			{
				for (int i = 0; i + gap < array.Count; i++)
				{
					int j = i + gap;
					int temp = array[j];

					while (j - gap >= 0 && array[j - gap] > temp)
					{
						array[j] = array[j - gap];
						j -= gap;
					}

					array[j] = temp;
				}
			}
		}
	}
}
