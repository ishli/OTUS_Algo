﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Fibo
{
	public class Fibo13 : ITask
	{

		public string Run(string[] data)
		{
			var number = Convert.ToInt64(data[0]);
			var result = CaclucalteFibo(number);

			return result.ToString();
		}

		private long CaclucalteFibo(long number)
		{
			//if (number == 0)
			//{
			//	return 0;
			//}

			//if (number == 1)
			//{
			//	return 1;
			//}

			var fi = (1 + Math.Sqrt(5)) + 0.5;


			double b = 1.0;


			//for (int i = 0; i < number; i++)
			//{
			//	b *= fi;
			//}

			var f1 = Math.Pow(fi, number);
			var result = Math.Floor(f1 / Math.Sqrt(5) + 0.5);

			return (long)result;
		}
	}
}
