using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSortersUint16
{
	public class BucketSort : ISorterUint16
	{
		public List<ushort> Sort(List<ushort> list)
		{
			var buckets = CreateBuckets(list);

			var result = GetElementsFromBuckets(buckets, list.Count);

			return result;
		}

		private List<ushort> GetElementsFromBuckets(SortedDictionary<ushort, List<ushort>> buckets, int resultCount)
		{
			var index = 0;

			var result = Enumerable.Repeat<ushort>(0, resultCount).ToList();

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

		private SortedDictionary<ushort, List<ushort>> CreateBuckets(List<ushort> list)
		{
			var max = list.Max();

			var buckets = new SortedDictionary<ushort, List<ushort>>();

			for (ushort i = 0; i < max; i++)
			{
				buckets[i] = new List<ushort>(1);
			}

			for (var i = 0; i < list.Count; i++)
			{
				var current = list[i];

				var index = current;

				var elementInBucket = buckets.ContainsKey(index) ? buckets[index] : null;
				if (elementInBucket == null)
				{
					buckets[index] = new List<ushort> { current };
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
