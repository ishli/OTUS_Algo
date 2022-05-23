using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Prime
{
	public class Prime15 : ITask
	{
		private long count = 0;
		private long[] primes;

		public string Run(string[] data)
		{
			var maxNumber = Convert.ToInt64(data[0]);
			var result = CountPrimes(maxNumber);

			return result.ToString();
		}

		private long CountPrimes(long maxNumber)
		{
			if (maxNumber == 1)
			{
				return 0;
			}

			count = 0;
			primes = new long[maxNumber / 2 + 1];
			primes[count++] = 2;

			for (int i = 3; i <= maxNumber; i++)
			{
				if (IsPrime(i))
				{
					primes[count++] = i;
				}
			}

			return count;

			bool IsPrime(long n)
			{
				long sqrtN = (long)Math.Sqrt(n);

				for (long i = 0; primes[i] <= sqrtN; i++)
				{
					if (n % primes[i] == 0)
					{
						return false;
					}
				}

				return true;
			}
		}
	}
}
