using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSorters
{
	public class BucketSort : ISorter
	{
		public List<int> Sort(List<int> list)
		{
			var buckets = CreateBuckets(list);

			var result = GetElementsFromBuckets(buckets, list.Count);

			return result;
		}

		private List<int> GetElementsFromBuckets(SortedDictionary<int, List<int>> buckets, int resultCount)
		{
			var index = 0;

			var result = Enumerable.Repeat(0, resultCount).ToList();

			for (var i = 0; i < buckets.Count; i++)
			{
				var t = buckets.ElementAt(i);
				if (t.Value == null || t.Value.Count == 0)
					continue;

				if (t.Value.Count == 1)
				{
					result[index++] = t.Value.First();
				}
				else
				{
					t.Value.ForEach(x => { result[index++] = x; });
				}
			}

			return result;
		}

		private SortedDictionary<int, List<int>> CreateBuckets(List<int> list)
		{
			var max = list.Max();

			var buckets = new SortedDictionary<int, List<int>>();

			for (int i = 0; i < max; i++)
			{
				buckets[i] = new List<int>(1);
			}

			for (var i = 0; i < list.Count; i++)
			{
				var current = list[i];

				var index = (int)(current * (long)list.Count / (max + 1));

				var elementInBucket = buckets.ContainsKey(index) ? buckets[index] : null;
				if (elementInBucket == null)
				{
					buckets[index] = new List<int> { current };
				}
				else
				{
					var temp = buckets[index];
					var indexForInsert = 0;
					for (int j = 0; j < temp.Count; j++)
					{
						if (temp[j] < current)
						{
							indexForInsert = j + 1;
						}
					}
					temp?.Insert(indexForInsert, current);
				}
			}


			return buckets;
		}
	}
}
