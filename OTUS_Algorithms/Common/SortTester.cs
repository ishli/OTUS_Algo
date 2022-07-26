using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class SortTester
	{
		private ISortTask _task;
		private string _path;

		public SortTester(ISortTask task, string path)
		{
			_task = task;
			_path = path;
		}

		public void RunTest()
		{
			int testNumber = 0;

			Stopwatch stopWatch = new Stopwatch();

			while (true )//&& testNumber <= 4)
			{
				string inFile = $"{_path}test.{testNumber}.in";
				string outFile = $"{_path}test.{testNumber}.out";

				if (!File.Exists(inFile) || !File.Exists(outFile))
				{
					break;
				}

				stopWatch.Start();
				var result = RunTest(inFile, outFile);

				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;

				if (result)
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				Console.WriteLine(ts.TotalMilliseconds);

				testNumber++;
			}
		}

		private bool RunTest(string inFile, string outFile)
		{
			try
			{
				string[] data = File.ReadAllLines(inFile);
				var count = int.Parse(data[0]);
				//Console.WriteLine(count);
				var array = data[1].Split(" ").Select(x => int.Parse(x)).ToList();

				_task.Sort(array);

				var result = _task.IsSorted(array);
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}
