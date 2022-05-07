using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
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
			while (true)
			{
				string inFile = $"{_path}test.{testNumber}.in";
				string outFile = $"{_path}test.{testNumber}.out";

				if (!File.Exists(inFile) || !File.Exists(outFile))
				{
					break;
				}

				var result = RunTest(inFile, outFile);

				if (result)
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				Console.WriteLine($"Test #{testNumber}: " + result);

				testNumber++;
			}
		}

		private bool RunTest(string inFile, string outFile)
		{
			try
			{
				string[] data = File.ReadAllLines(inFile);
				string expect = File.ReadAllText(outFile).Trim();

				string result = _task.Run(data).Trim();

				return expect == result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}
