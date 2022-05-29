using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4_Binary
{
	public class Chess : ITask
	{
		private int[] b = new int[256];
		private const ulong noA = 0xFeFeFeFeFeFeFeFe;
		private const ulong noAB = 0xFcFcFcFcFcFcFcFc;
		private const ulong noH = 0x7f7f7f7f7f7f7f7f;
		private const ulong noGH = 0x3f3f3f3f3f3f3f3f;

		private const ulong vertical = 0x101010101010101;
		private const ulong horizontal = 0xff;

		private const ulong Plus45Degree = 0x8040201008040201;
		private const ulong Minus45Degree = 0x102040810204080;


		public Chess()
		{
			FillBits();
		}

		public string Run(string[] data)
		{
			var number = Convert.ToInt32(data[0]);
			var mask = GetQueenBitboardMoves(number);
			var count = PopCnt3(mask);
			return $"{count}|{mask}";
		}

		private void FillBits()
		{
			for (int i = 0; i <= 255; i++)
			{
				b[i] = PopCnt2((ulong)i);
			}
		}

		private ulong GetKingBitboardMoves(int pos)
		{
			ulong K = 1UL << pos;
			ulong Ka = K & noA;
			ulong Kh = K & noH;

			ulong mask =
				(Ka << 7) | (K << 8) | (Kh << 9) |
				(Ka >> 1) | (Kh << 1) |
				(Ka >> 9) | (K >> 8) | (Kh >> 7);

			return mask;
		}

		private ulong GetHorseBitboardMoves(int pos)
		{

			ulong horseBits = 1UL << pos;

			ulong mask =
				noGH & (horseBits << 6 | horseBits >> 10)
			 | noH & (horseBits << 15 | horseBits >> 17)
			 | noA & (horseBits << 17 | horseBits >> 15)
			 | noAB & (horseBits << 10 | horseBits >> 6);

			return mask;
		}

		private ulong GetRookBitboardMoves(int pos)
		{
			int moveHorizontal = pos / 8;
			int moveVertical = pos % 8;

			ulong newHorizontal = horizontal << (8 * moveHorizontal);
			ulong newVertical = vertical << moveVertical;
			ulong cross = newHorizontal | newVertical;
			ulong rookBits = 1UL << pos;

			ulong mask = rookBits ^ cross;
			return mask;
		}

		private ulong GetBishopBitboardMoves(int pos)
		{
			int h = pos % 8;
			int v = pos / 8;

			int pointPositionForPlus45Degree = GetPointPositionForVector(0, 0, 7, 7, h, v); // < 0 - левее
			int pointPositionForMinus45Degree = GetPointPositionForVector(0, 7, 7, 0, h, v); // < 0 - ниже

			int moveHorizontal = Math.Abs(h - v);
			int moveVertical = Math.Abs(v - (7 - h));

			ulong newPlus45Degree = pointPositionForPlus45Degree >= 0
				? Plus45Degree << (8 * moveHorizontal)
				: Plus45Degree >> (8 * moveHorizontal);

			ulong newMinus45Degree = pointPositionForMinus45Degree >= 0
				? Minus45Degree << (8 * moveVertical)
				: Minus45Degree >> (8 * moveVertical);
			ulong cross = newPlus45Degree | newMinus45Degree;
			ulong bishopBits = 1UL << pos;

			ulong mask = bishopBits ^ cross;
			return mask;
		}

		private ulong GetQueenBitboardMoves(int pos)
		{
			ulong mask = GetRookBitboardMoves(pos) | GetBishopBitboardMoves(pos);
			return mask;
		}

		private int GetPointPositionForVector(int ax, int ay, int bx, int by, int px, int py)
		{
			return (bx - ax) * (py - ay) - (by - ay) * (px - ax);
		}

		private int PopCnt(ulong mask)
		{
			int count = 0;
			while (mask > 0)
			{
				if ((mask & 1) == 1)
				{
					count++;
				}
				mask >>= 1;
			}
			return count;
		}

		private int PopCnt2(ulong mask)
		{
			int count = 0;
			while (mask > 0)
			{
				count++;
				mask &= mask - 1;
			}
			return count;
		}

		private int PopCnt3(ulong mask)
		{
			int count = 0;
			while (mask > 0)
			{
				count += b[mask & 255];
				mask >>= 8;
			}
			return count;
		}
	}
}
