using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_9_FastSort.FastSortersUint16
{
	public class SortManagerUint16
	{
		private readonly string PathToBinaryFile = @"D:\New folder\9\test.bin";

		public void Run()
		{
			TestArrayFromBinaryFile(new CountingSort());
			TestArrayFromBinaryFile(new RadixSort());
			TestArrayFromBinaryFile(new BucketSort());
		}

		private void TestArrayFromBinaryFile(ISorterUint16 sorter)
		{
			CreateBinaryFileForTest();
			var array = ReadBinaryFile(PathToBinaryFile);
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			array = sorter.Sort(array);
			TimeSpan ts = stopWatch.Elapsed;
			Show(array, ts);
		}

		private void CreateBinaryFileForTest()
		{
			var testArray = GenerateArray(10_000_000);

			if (File.Exists(PathToBinaryFile))
			{
				File.Delete(PathToBinaryFile);
			}

			using (FileStream fileStream = new FileStream(PathToBinaryFile, FileMode.Create))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				foreach (UInt16 frameCode in testArray)
				{
					binaryWriter.Write(frameCode);
				}
			}
		}

		private List<UInt16> ReadBinaryFile(string path)
		{
			var result = new List<UInt16>(10_000_000);
			using (FileStream fs = File.OpenRead(path))
			using (BinaryReader reader = new BinaryReader(fs))
			{
				while (reader.BaseStream.Position != reader.BaseStream.Length)
				{
					var item = reader.ReadUInt16();
					result.Add(item);
				}
			}

			return result;
		}

		private List<UInt16> GenerateArray(int count)
		{
			var result = new List<UInt16>(count);
			var random = new Random();

			var max = (int)UInt16.MaxValue;
			for (int i = 0; i < count; i++)
			{
				var item = random.Next(0, max);
				result.Add((UInt16)item);
			}

			return result;
		}

		private void Show(List<UInt16> array, TimeSpan ts)
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

		private bool IsSorted(List<UInt16> array)
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
