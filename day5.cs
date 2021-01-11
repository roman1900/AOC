using System;
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