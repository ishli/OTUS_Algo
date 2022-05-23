using _1_3_Algebra.Fibo;
using _1_3_Algebra.Pow;
using _1_3_Algebra.Prime;
using Common;
using System;

namespace _1_3_Algebra
{
	class Program
	{
		static void Main(string[] args)
		{
			ITask lucky = new Prime15();
			var tester = new Tester(lucky, @"D:\New folder\5.Primes\");
			tester.RunTest();
			Console.ReadLine();
		}
	}
}
