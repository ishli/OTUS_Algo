using Common;
using System;

namespace LuckyNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			ITask lucky = new Lucky();
			var tester = new Tester(lucky, @"D:\New folder\1.Tickets\");
			tester.RunTest();
			Console.ReadLine();
		}
	}
}
