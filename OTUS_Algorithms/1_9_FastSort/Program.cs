using _1_9_FastSort;
using _1_9_FastSort.FastSorters;
using _1_9_FastSort.FastSortersUint16;
using System.Diagnostics;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		(new SortManager()).Run();

		Console.WriteLine();

		(new SortManagerUint16()).Run();
	}
}