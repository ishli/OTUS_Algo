using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Pow
{
	public class Pow01 : ITask
	{
		public string Run(string[] data)
		{
			var number = Convert.ToDouble(data[0]);
			var pow = Convert.ToInt64(data[1]);
			var result = Pow(number, pow);

			return result.ToString();
		}

		private double Pow(double number, long pow)
		{
			double result = 1.0D;
			for (long i = 0; i < pow; i++)
			{
				result *= number;
			}

			return result;
		}
	}
}
