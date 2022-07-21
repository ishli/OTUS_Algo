using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Utils
	{
		public static void Swap(List<int> array, int x, int y)
		{
			var t = array[x];
			array[x] = array[y];
			array[y] = t;
		}
	}
}
