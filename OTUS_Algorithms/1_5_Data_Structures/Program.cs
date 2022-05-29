using System;

namespace _1_5_Data_Structures
{
	class Program
	{
		static void Main(string[] args)
		{
			//var t = new ArrayListWrapper<int>();
			//t.Add(1);
			//t.Add(2);
			//t.Add(3);
			//t.Add(4);
			//Console.WriteLine(t.Get(2));
			//t.Add(0, 0);
			//t.Add(5, 2);
			//Console.WriteLine(t.Length());
			//t.Remove(0);
			//Console.WriteLine(t.Length());
			//t.Remove(2);
			//Console.WriteLine(t.Length());

			var t = new PriorityQueue<int>();
			t.enqueue(1, 2);
			t.enqueue(1, 3);
			t.enqueue(2, 5);
			Console.WriteLine(t.dequeue());
			Console.WriteLine(t.dequeue());
			t.enqueue(2, 4);
			Console.WriteLine(t.dequeue());
		}
	}
}
