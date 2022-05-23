using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Pow
{
	public class Pow12 : ITask
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
			if (pow == 0)
			{
				return 1.0;
			}

			double result = 1.0;

			for (; pow > 1; pow /= 2)
			{
				if (pow % 2 == 1)
				{
					result *= number;
				}

				number *= number;
			}

			result *= number;

			return result;
		}
	}
}
