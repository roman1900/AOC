using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace AOC
{
	class Day2
	{
		public static bool ValidPassword(string check)
		{
			
			Regex reggie = new Regex(@"^(\d*)-(\d*)\s(\w):\s(.*)");
			Match mc = reggie.Match(check);
			int hits = mc.Groups[4].Value.ToList<char>().Count(x => x == mc.Groups[3].Value[0]);
			return (hits >= Int32.Parse(mc.Groups[1].Value) && hits <= Int32.Parse(mc.Groups[2].Value));
			
		}
		public static bool ValidPasswordAlt(string check)
		{
			Regex reggie = new Regex(@"^(\d*)-(\d*)\s(\w):\s(.*)");
			Match mc = reggie.Match(check);
			int Pos1 = Int32.Parse(mc.Groups[1].Value) > mc.Groups[4].Value.Length ? -1 : Int32.Parse(mc.Groups[1].Value) - 1;
			int Pos2 = Int32.Parse(mc.Groups[2].Value) > mc.Groups[4].Value.Length ? -1 : Int32.Parse(mc.Groups[2].Value) - 1;

			char checkvalue = mc.Groups[3].Value[0] ;
			
			if ((Pos1 != -1 ? mc.Groups[4].Value[Pos1] == checkvalue : false)
				^ (Pos2 != -1 ? mc.Groups[4].Value[Pos2] == checkvalue : false))
				{
					
					WriteLineWithHighlight( mc.Groups[4].Value,new int[]{Int32.Parse(mc.Groups[1].Value)-1,Int32.Parse(mc.Groups[2].Value)-1});
				}
			return ((Pos1 != -1 ? mc.Groups[4].Value[Pos1] == checkvalue : false)
				^ (Pos2 != -1 ? mc.Groups[4].Value[Pos2] == checkvalue : false));
				
			
		}
		private static void WriteLineWithHighlight(string input, int[] posHighlight)
		{
			int stringpos=0;
			for (int i=0; i<posHighlight.Length; i++)
			{
				if (posHighlight[i]<input.Length)
				{
					Console.Write(input.Substring(stringpos,posHighlight[i]-stringpos));
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(input[posHighlight[i]]);
					Console.ResetColor();
					stringpos=posHighlight[i]+1;
				}
			}
			if (stringpos<=input.Length)
			{
				Console.WriteLine(input.Substring(stringpos,input.Length - stringpos ));
			}
			else {
			Console.WriteLine();
			}
		}
	}

}