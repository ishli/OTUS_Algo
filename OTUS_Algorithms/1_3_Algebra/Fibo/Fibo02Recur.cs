using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Fibo
{
	public class Fibo02Recur : ITask
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
			else
			{
				return CaclucalteFibo(number - 1) + CaclucalteFibo(number - 2);
			}
		}
	}
}
