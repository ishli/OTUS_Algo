using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public class ArrayListWrapper<T> : IArray<T>
	{
		private ArrayList _array = new ArrayList();
		public void Add(T t)
		{
			_array.Add(t);
		}

		public void Add(T t, int index)
		{
			_array.Insert(index, t);
		}

		public T Get(int index)
		{
			return (T)_array[index];
		}

		public int Length()
		{
			return _array.Count;
		}

		public T Remove(int index)
		{
			var result = (T)_array[index];
			_array.RemoveAt(index);

			return result;
		}
	}
}
