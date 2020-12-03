using System;
using System.Linq;
namespace AOC
{
	class Day1
	{
		
		public static int[] TheNumber(int target,int[] inputlist)
		{
			var dd = inputlist.ToDictionary( x => x, x=> x);
			foreach (var no in dd.Keys)
			{
				if (dd.ContainsKey(target-no))
				{
					return new int[]{no, target-no};
				}
			};
			return new int[]{0,0};
		}
		public static void TheTrips(int target,int[] inputlist)
		{
			
			for (int i = 0; i < inputlist.Count(); i++)
			{
				int[] match = TheNumber(target - inputlist[i],inputlist); 
				if (match[0] != 0)
				{
					Console.WriteLine($"{inputlist[i]} , {match[0]} , {match[1]}: {inputlist[i] * match[0] * match[1]}");
					break;
				}
			}	
		}
		
	}
}