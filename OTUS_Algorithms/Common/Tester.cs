using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Tester
	{
		private ITask _task;
		private string _path;

		public Tester(ITask task, string path)
		{
			_task = task;
			_path = path;
		}

		public void RunTest()
		{
			int testNumber = 0;

			Stopwatch stopWatch = new Stopwatch();

			while (true)
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
				Console.WriteLine($"Test #{testNumber}: " + result + "\t\t" + ts.TotalMilliseconds);

				testNumber++;
			}
		}

		public void RunTestForComplexResult()
		{
			int testNumber = 0;

			Stopwatch stopWatch = new Stopwatch();

			while (true)
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
				Console.WriteLine($"Test #{testNumber}: " + result + "\t\t" + ts.TotalMilliseconds);

				testNumber++;
			}
		}

		private bool RunTest(string inFile, string outFile)
		{
			try
			{
				string[] data = File.ReadAllLines(inFile);
				string[] expect = File.ReadAllLines(outFile);

				var resultData = _task.Run(data).Split("|");

				return expect[0].Trim() == resultData[0].Trim() && expect[1].Trim() == resultData[1].Trim();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}
