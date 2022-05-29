using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
	public class Lucky : ITask
	{
		private long count = 0;
		public string Run(string[] data)
		{
			var length = Convert.ToInt32(data[0]);
			count = 0;
			GetLuckyCountFast(length);
			return count.ToString();
		}

		private void GetLuckyCountRecursion(int length, int sumLeft, int sumRight)
		{
			if (length == 0)
			{
				if (sumLeft == sumRight)
				{
					count++;
				}
				return;
			}

			for (int a = 0; a < 10; a++)
			{
				for (int b = 0; b < 10; b++)
				{
					GetLuckyCountRecursion(length - 1, sumLeft + a, sumRight + b);
				}
			}
		}

		private void GetLuckyCountFast(int length)
        {
			var baseArray = new List<long> { 1 };
			var result = 0l;

			for (int i = 0; i < length; i++)
            {
				var matrix = new long[10, 10*(i+1)];
				FillMatrixByZero(matrix);
				FillMatrixByBase(matrix, baseArray);
				var newBaseArray = GetSumOnEveryColumn(matrix);
				result = newBaseArray.Select(x => x * x).Sum();
				baseArray = newBaseArray;
            }

			count = result;
        }

        private void FillMatrixByBase(long[,] matrix, List<long> baseArray)
        {
			var rowsCount = matrix.GetLength(0);

			for (int i = 0; i < rowsCount; i++)
			{
				for (int k = 0; k < baseArray.Count; k++)
				{
					matrix[i, i + k] = baseArray[k];
				}
			}
		}

        private List<long> GetSumOnEveryColumn(long[,] matrix)
        {
			var rowsCount = matrix.GetLength(0);
			var columnCount = matrix.GetLength(1);

			var result = new List<long>(columnCount);

			for (int i = 0; i < columnCount; i++)
            {
				var temp = 0L;
                for (int j = 0; j < rowsCount; j++)
                {
					temp += matrix[j, i];
                }

				result.Add(temp);
            }

			return result;
		}

        private void FillMatrixByZero(long[,] matrix)
        {
			var rowsCount = matrix.GetLength(0);
			var columnCount = matrix.GetLength(1);
            for (int i = 0; i < rowsCount; i++) 
            {
                for (int j = 0; j < columnCount; j++)
                {
					matrix[i, j] = 0L;
                }
            }
        }
    }
}
