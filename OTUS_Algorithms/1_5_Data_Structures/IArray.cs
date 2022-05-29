using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Data_Structures
{
	public interface IArray<T>
	{
		int Length();
		void Add(T t);
		void Add(T t, int index);
		T Get(int index);
		T Remove(int index);
	}
}
