using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Prime
{
	public class Prime03 : ITask
	{
		public string Run(string[] data)
		{
			var maxNumber = Convert.ToInt64(data[0]);
			var result = CountPrimes(maxNumber);

			return result.ToString();
		}

		private long CountPrimes(long maxNumber)
		{
			long count = 0;
			for (int i = 1; i <= maxNumber; i++)
			{
				if (IsPrime(i))
				{
					count++;
				}
			}

			return count;

			bool IsPrime(long n)
			{
				long temp = 0;
				for (int i = 1; i <= n; i++)
				{
					if (n % i == 0)
					{
						temp++;
					}
				}

				return temp == 2;
			}
		}
	}
}
