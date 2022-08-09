using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSortersUint16
{
	public class RadixSort : ISorterUint16
	{
		public List<UInt16> Sort(List<UInt16> list)
		{
			var temp = list;
			var maxNumber = list.Max();
			var dozens = maxNumber.ToString().Length;

			var maxDozen = (int)Math.Pow(10, dozens);

			for (var denominator = 10; denominator <= maxDozen; denominator *= 10)
			{
				temp = SortByCounting(temp, denominator);
			}

			return temp;
		}

		private List<UInt16> SortByCounting(List<UInt16> array, int denominator)
		{
			var uniqs = GetUniqueKeys(array, denominator);

			return FormSortedArray(array, uniqs, denominator);
		}

		private List<UInt16> FormSortedArray(List<UInt16> array, Dictionary<UInt16, int> uniqs, int denominator)
		{
			var temp = Enumerable.Repeat<ushort>(0, array.Count).ToList();
			for (int i = array.Count - 1; i >= 0; i--)
			{
				var current = GetElement(array, i, denominator);
				var indexUpperBound = --uniqs[current];
				temp[indexUpperBound] = array[i];
			}

			return temp;
		}

		private Dictionary<UInt16, int> GetUniqueKeys(List<UInt16> array, int denominator)
		{
			var result = new Dictionary<UInt16, int>();

			for (int i = 0; i < array.Count; i++)
			{
				var t = GetElement(array, i, denominator);
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

		private UInt16 GetElement(List<UInt16> array, int index, int denominator)
		{
			var result = (UInt16)(array[index] % denominator / (denominator / 10));

			return result;
		}
	}
}
