using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Prime
{
	public class Prime17 : ITask
	{
		public string Run(string[] data)
		{
			var maxNumber = Convert.ToInt32(data[0]);
			var result = CountPrimes(maxNumber);

			return result.ToString();
		}

		private long CountPrimes(int input)
		{
			// BitArray - компактный массив двоичных значений, специальная коллекция в .net 
			var divs = new BitArray(input + 1);
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
