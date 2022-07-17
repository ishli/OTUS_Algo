using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Simple_Sorts
{
	public class Common
	{
		public static void Swap(List<int> array, int x, int y)
		{
			var t = array[x];
			array[x] = array[y];
			array[y] = t;
		}
	}
}
