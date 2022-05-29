using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public interface IQueue<T>
	{
		void enqueue(int priority, T item);

		T dequeue();
	}

	public class PriorityQueue<T> : IQueue<T>
	{
		private List<KeyValuePair<int, List<T>>> queue = new List<KeyValuePair<int, List<T>>>();
		public T dequeue()
		{
			var maxPriority = queue.Max(x => x.Key);

			var list = queue.First(x => x.Key == maxPriority).Value;

			var element = list.First();

			if (list.Count == 1)
			{
				var index = queue.FindIndex(x => x.Key == maxPriority);
				queue.RemoveAt(index);
			}
			else
			{
				list.RemoveAt(0);
			}

			return element;
		}

		public void enqueue(int priority, T item)
		{
			if (queue.Any(x => x.Key == priority))
			{
				queue.First(x => x.Key == priority).Value.Add(item);
			}
			else
			{
				queue.Add(new KeyValuePair<int, List<T>>(priority, new List<T> { item }));
				queue = queue.OrderBy(x => x.Key).ToList();
			}
		}
	}
}
