using Common;
using System;

namespace _1_4_Binary
{
	class Program
	{
		static void Main(string[] args)
		{
			ITask lucky = new Chess();
			var tester = new Tester(lucky, @"D:\New folder\0.BITS\5.Bitboard - Ферзь\");
			tester.RunTestForComplexResult();
		}
	}
}
