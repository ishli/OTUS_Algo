using _1_7_Heap_Sort;
using Common;

class Program
{
	static void Main(string[] args)
	{
		ISortTask task = new HeapSort();

		var tester = new SortTester(task, @"D:\New folder\6.sorting_tests\0.random\");
		Console.WriteLine("random");
		tester.RunTest();

		tester = new SortTester(task, @"D:\New folder\6.sorting_tests\1.digits\");
		Console.WriteLine("digits");
		tester.RunTest();

		tester = new SortTester(task, @"D:\New folder\6.sorting_tests\2.sorted\");
		Console.WriteLine("sorted");
		tester.RunTest();

		tester = new SortTester(task, @"D:\New folder\6.sorting_tests\3.revers\");
		Console.WriteLine("revers");
		tester.RunTest();
	}
}