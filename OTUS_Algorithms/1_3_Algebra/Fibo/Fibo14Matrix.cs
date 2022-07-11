using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Algebra.Fibo
{
	public class Fibo14Matrix : ITask
	{
		public string Run(string[] data)
		{
			var number = Convert.ToInt64(data[0]);
			var result = CaclucalteFibo(number);

			return result.ToString();
		}

		private long CaclucalteFibo(long input)
		{
			if (input == 0)
			{
				return 0;
			}

			if (input == 1)
			{
				return 1;
			}

			var res = IdentityMatrix();
			var @base = BaseMatrix();

			while (input > 1)
			{
				if ((input & 1) == 1)
				{
					res = MultipleMatrixes(res, @base);
				}
				@base = MultipleMatrixes(@base, @base);
				input >>= 1;
			}

			var result = MultipleMatrixes(res, @base);

			return result[1, 0];
		}

		long[,] BaseMatrix()
		{
			long[,] m = new long[2, 2];
			m[0, 0] = 1; m[0, 1] = 1;
			m[1, 0] = 1; m[1, 1] = 0;

			return m;
		}

		long[,] IdentityMatrix()
		{
			long[,] m = new long[2, 2];
			m[0, 0] = 1; m[0, 1] = 0;
			m[1, 0] = 0; m[1, 1] = 0;

			return m;
		}

		long[,] MultipleMatrixes(long[,] a, long[,] b)
		{
			long[,] r = new long[2, 2];
			r[0, 0] = a[0, 0] * b[0, 0] + a[1, 0] * b[0, 1];
			r[1, 0] = a[0, 0] * b[1, 0] + a[1, 0] * b[1, 1];
			r[0, 1] = a[0, 1] * b[0, 0] + a[1, 1] * b[0, 1];
			r[1, 1] = a[0, 1] * b[1, 0] + a[1, 1] * b[1, 1];

			return r;
		}
	}


}
