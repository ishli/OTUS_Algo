using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
	public class Lucky : ITask
	{
		private long count = 0;
		public string Run(string[] data)
		{
			var length = Convert.ToInt32(data[0]);
			count = 0;
			GetLuckyCountRecursion(length, 0, 0);
			return count.ToString();
		}

		private void GetLuckyCountRecursion(int length, int sumLeft, int sumRight)
		{
			if (length == 0)
			{
				if (sumLeft == sumRight)
				{
					count++;
				}
				return;
			}

			for (int a = 0; a < 10; a++)
			{
				for (int b = 0; b < 10; b++)
				{
					GetLuckyCountRecursion(length - 1, sumLeft + a, sumRight + b);
				}
			}
		}
	}
}
