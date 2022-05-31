using System;
using System.Diagnostics;

namespace _1_5_Data_Structures
{
	class Program
	{
		private const int ArrayLength = 10000;
		private static Stopwatch stopWatch = new Stopwatch();
		static void Main(string[] args)
		{
			var t = new SpaceArray<int>();
			var t2 = new SpaceArray<int>();
			var t3 = new SpaceArray<int>();
			FillArrayFromEnd(t);
			FillArrayFromStart(t2);
			FillArrayRandom(t3);
			ReadFromStart(t);
			ReadFromEnd(t);
			ReadFromRandom(t);
			DeleteFromStart(t);
			DeleteFromEnd(t2);
			DeleteRandom(t3);


			//var t = new PriorityQueue<int>();
			//t.enqueue(1, 2);
			//t.enqueue(1, 3);
			//t.enqueue(2, 5);
			//Console.WriteLine(t.dequeue());
			//Console.WriteLine(t.dequeue());
			//t.enqueue(2, 4);
			//Console.WriteLine(t.dequeue());
		}

		private static void FillArrayFromEnd(IArray<int> array)
		{
			Console.WriteLine(nameof(FillArrayFromEnd));
			stopWatch.Restart();

			var rnd = new Random();
			for (int i = 0; i < ArrayLength; i++)
			{
				array.Add(rnd.Next(0, 1000));
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void FillArrayFromStart(IArray<int> array)
		{
			Console.WriteLine(nameof(FillArrayFromStart));
			stopWatch.Restart();

			var rnd = new Random();
			for (int i = 0; i < ArrayLength; i++)
			{
				array.Add(rnd.Next(0, 1000), 0);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void FillArrayRandom(IArray<int> array)
		{
			Console.WriteLine(nameof(FillArrayRandom));
			stopWatch.Restart();

			var rnd = new Random();

			array.Add(rnd.Next(0, 1000));

			for (int i = 0; i < ArrayLength - 1; i++)
			{
				array.Add(rnd.Next(0, 1000), rnd.Next(0, array.Length() - 1));
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void ReadFromStart(IArray<int> array)
		{
			Console.WriteLine(nameof(ReadFromStart));
			stopWatch.Restart();

			int t;
			for (int i = 0; i < ArrayLength; i++)
			{
				t = array.Get(i);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void ReadFromRandom(IArray<int> array)
		{
			Console.WriteLine(nameof(ReadFromRandom));
			stopWatch.Restart();

			var rnd = new Random();
			int t;
			for (int i = 0; i < ArrayLength; i++)
			{
				t = array.Get(rnd.Next(0, ArrayLength - 1));
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void ReadFromEnd(IArray<int> array)
		{
			Console.WriteLine(nameof(ReadFromEnd));
			stopWatch.Restart();

			int t;
			for (int i = ArrayLength - 1; i >= 0; i--)
			{
				t = array.Get(0);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void DeleteFromStart(IArray<int> array)
		{
			Console.WriteLine(nameof(DeleteFromStart));
			stopWatch.Restart();

			for (int i = 0; i < ArrayLength; i++)
			{
				array.Remove(0);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void DeleteFromEnd(IArray<int> array)
		{
			Console.WriteLine(nameof(DeleteFromEnd));
			stopWatch.Restart();

			for (int i = 0; i < ArrayLength; i++)
			{
				array.Remove(array.Length() - 1);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}

		private static void DeleteRandom(IArray<int> array)
		{
			Console.WriteLine(nameof(DeleteRandom));
			stopWatch.Restart();
			var rnd = new Random();

			for (int i = 0; i < ArrayLength; i++)
			{
				var t = rnd.Next(0, array.Length() - 1);
				array.Remove(t);
			}

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			Console.WriteLine(ts.TotalMilliseconds);
		}
	}
}
