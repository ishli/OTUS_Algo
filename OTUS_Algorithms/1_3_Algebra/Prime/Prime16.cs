using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Prime
{
	public class Prime16 : ITask
	{
		public string Run(string[] data)
		{
			var maxNumber = Convert.ToInt64(data[0]);
			var result = CountPrimes(maxNumber);

			return result.ToString();
		}

		private long CountPrimes(long input)
		{
			var divs = new bool[input + 1];
			var sqrt = (int)Math.Sqrt(input);
			var count = 0;

			for (int i = 2; i <= input; i++)
			{
				if (!divs[i])
				{
					count++;
					if (i <= sqrt)
					{
						for (int j = i * i; j <= input; j += i)
						{
							divs[j] = true;
						}
					}
				}
			}
			return count;

		}
	}
}
