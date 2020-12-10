using System;
namespace AOC
{
	class Day3
	{
		public static long TreesHit(string[] map,int right, int down)
		{
			int row = down;
			int col = 0;
			long trees = 0;
			while (row < map.Length)
			{
				
				col = (col + right) % (map[row].Length);
				//Console.WriteLine($"{col}");
				if (map[row][col] == '#')
				{
					trees++;
				}
				row=row+down;
			}
			return trees;
		}
	}
}