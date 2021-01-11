using System;
using System.Linq;
using System.Collections.Generic;
namespace AOC
{
	class Day5
	{
		public static int MaxSeatID(string[] data)
		{
			int maxid = -1;
			foreach (string line in data)
			{
				int row = -1;
				int col = -1;
				int seatID = -1;
				
				row = binaryPosition(line.Substring(0,7),'F',0,127);

				
				col = binaryPosition(line.Substring(7),'L',0,7);
				seatID = (row * 8) + col;
				maxid = seatID > maxid ? seatID : maxid;
			}
			return maxid;
		}
		public static int MySeat(string[] data)
		{
			
			List<int> seatIDRange = new List<int>();
			foreach (string line in data)
			{
				seatIDRange.Add((binaryPosition(line.Substring(0,7),'F',0,127)* 8)+binaryPosition(line.Substring(7),'L',0,7));
			}
			seatIDRange = seatIDRange.OrderBy(x => x).ToList();
			int upper = (126 * 8) + 7;
			for (int i=8; i <= upper;i++)
			{
				if (!seatIDRange.Contains(i) && seatIDRange.Contains(i-1) && seatIDRange.Contains(i+1)) return i;
			}
			return -1;
		}
		static private int binaryPosition(string locator,char left,int low, int high)
		{
			for(int i=0; i<locator.Length; i++)
			{
				float midpoint = low + (high - low) / 2;
				low = locator[i] == left ? low : (int) midpoint + 1 ;
				high = locator[i] == left ? (int)Math.Floor(midpoint) : high;
			}
			return low == high ? low : -1;
		}
	}
}