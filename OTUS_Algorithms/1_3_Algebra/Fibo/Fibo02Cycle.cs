using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Fibo
{
	public class Fibo02Cycle : ITask
	{
		public string Run(string[] data)
		{
			var number = Convert.ToInt64(data[0]);
			var result = CaclucalteFibo(number);

			return result.ToString();
		}

		private long CaclucalteFibo(long number)
		{
			if (number == 0)
			{
				return 0;
			}

			if (number == 1)
			{
				return 1;
			}

			long a1 = 1;
			long a2 = 1;
			for (long i = 2; i < number; i++)
			{
				long a3 = a1 + a2;
				a1 = a2;
				a2 = a3;
			}

			return a2;
		}
	}
}
