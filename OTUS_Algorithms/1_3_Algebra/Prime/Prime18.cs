using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Prime
{
	public class Prime18 : ITask
	{
		public string Run(string[] data)
		{
			var maxNumber = Convert.ToInt32(data[0]);
			var result = CountPrimes(maxNumber);

			return result.ToString();
		}

		private long CountPrimes(int input)
		{
			var pr = new long[input + 1];
			var count = 0;
			var lp = new long[input + 1];

			for (int i = 2; i <= input; i++)
			{
				if (lp[i] == 0)
				{
					lp[i] = i;
					pr[count++] = i;
				}

				for (int j = 0; j < count; ++j)
				{
					var p = pr[j];
					if (p <= lp[i] && p * i <= input)
					{
						lp[p * i] = p;
					}
					else
					{
						break;
					}
				}
			}

			return count;
		}
	}
}
