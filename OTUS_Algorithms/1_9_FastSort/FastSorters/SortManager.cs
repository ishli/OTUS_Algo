using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSorters
{
	public class SortManager
	{
		public void Run()
		{
			TestArray(new CountingSort(), 100);
			TestArray(new CountingSort(), 1000);
			TestArray(new CountingSort(), 10_000);
			TestArray(new CountingSort(), 100_000);
			TestArray(new CountingSort(), 1_000_000);

			Console.WriteLine();

			TestArray(new RadixSort(), 100);
			TestArray(new RadixSort(), 1000);
			TestArray(new RadixSort(), 10_000);
			TestArray(new RadixSort(), 100_000);
			TestArray(new RadixSort(), 1_000_000);

			Console.WriteLine();

			TestArray(new BucketSort(), 100);
			TestArray(new BucketSort(), 1000);
			TestArray(new BucketSort(), 10_000);
			TestArray(new BucketSort(), 100_000);
			TestArray(new BucketSort(), 1_000_000);
		}

		private void TestArray(ISorter sorter, int count)
		{
			var array = GenerateArray(count);
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			array = sorter.Sort(array);
			TimeSpan ts = stopWatch.Elapsed;
			Show(array, ts);
		}

		private List<int> GenerateArray(int count)
		{
			var result = new List<int>(count);
			var random = new Random();

			for (int i = 0; i < count; i++)
			{
				var item = random.Next(0, 999);
				result.Add(item);
			}

			return result;
		}

		private void Show(List<int> array, TimeSpan ts)
		{
			if (IsSorted(array))
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private bool IsSorted(List<int> array)
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
