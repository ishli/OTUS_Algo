using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSorters
{
	public class CountingSort : ISorter
	{
		public List<int> Sort(List<int> array)
		{
			var uniqs = GetUniqueKeys(array);

			return FormSortedArray(array, uniqs);
		}

		private List<int> FormSortedArray(List<int> array, Dictionary<int, int> uniqs)
		{
			var temp = Enumerable.Repeat(0, array.Count).ToList();
			for (int i = array.Count - 1; i >= 0; i--)
			{
				var indexUpperBound = --uniqs[array[i]];
				temp[indexUpperBound] = array[i];
			}

			return temp;
		}

		private Dictionary<int, int> GetUniqueKeys(List<int> array)
		{
			var result = new Dictionary<int, int>();

			for (int i = 0; i < array.Count; i++)
			{
				var t = array[i];
				if (result.ContainsKey(t))
				{
					result[t]++;
				}
				else
				{
					result[t] = 1;
				}
			}

			result = result.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

			for (int i = 1; i < result.Count; i++)
			{
				var previous = result.ElementAt(i - 1);
				var current = result.ElementAt(i);

				result[current.Key] = previous.Value + current.Value;
			}

			return result;
		}
	}
}
