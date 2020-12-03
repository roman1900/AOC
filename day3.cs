using System;
namespace AOC
{
	class Day3
	{
		public static void TreesHit(string[] map)
		{
			int row = 1;
			int col = 0;
			int trees = 0;
			while (row < map.Length)
			{
				
				col = (col + 3) % (map[row].Length);
				//Console.WriteLine($"{col}");
				if (map[row][col] == '#')
				{
					trees++;
				}
				row++;
			}
			Console.WriteLine($"Hit {trees} trees");
		}
	}
}