using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
namespace AOC
{
	[Flags] public enum passport
	{
		byr	=	0x00000001,
		iyr =	0x00000010,
		eyr =	0x00000100,
		hgt =	0x00001000,
		hcl =	0x00010000,
		ecl =	0x00100000,
		pid =	0x01000000,
		cid =	0x10000000
	}
	class Day4
	{
		
		public static long PassportCount(string[] data,bool validate)
		{
			long count = 0;
			passport valid = (passport)0x01111111 ;
			passport checkthis = 0;
			for (int i=0; i<data.Length; i++)
			{

				if (data[i].Trim().Length==0)
				{
					if ((valid & checkthis) == valid)
					{
						count++;
					}
					checkthis = 0;
				}
				else 
				{
					Regex rgx = new Regex(@"(\w*):(#*\w*)");
					foreach (Match match in rgx.Matches(data[i]))
					{
						if (validate)
						{
							if (DataValid(match.Groups[1].Value,match.Groups[2].Value)) 
								checkthis |= (passport) Enum.Parse(typeof(passport), match.Groups[1].Value, true);
						} 
						else
							checkthis |= (passport) Enum.Parse(typeof(passport), match.Groups[1].Value, true);
					}

				}

			}
			return count;
		}
		public static bool DataValid(string field,string data)
		{
			string[] ecl = {"amb","blu","brn","gry","grn","hzl","oth"};
			bool valid = false;
			switch (field) 
			{
				case "byr":
					valid = Int32.Parse(data) >= 1920 && Int32.Parse(data) <= 2002;
					break;
				case "iyr":
					valid = Int32.Parse(data) >= 2010 && Int32.Parse(data) <= 2020;
					break;
				case "eyr":
					valid = Int32.Parse(data) >=2020 && Int32.Parse(data) <= 2030;
					break;
				case "hgt":
					if (data.Contains("cm")){
						valid = Int32.Parse(data.Replace("cm","")) >= 150 && Int32.Parse(data.Replace("cm","")) <= 193;
					}
					if (data.Contains("in")){
						valid = Int32.Parse(data.Replace("in","")) >= 59 && Int32.Parse(data.Replace("in","")) <= 76;
					}
					break;
				case "hcl":
					IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-us");
					valid = data.Length == 7 && data[0] == '#' && Int32.TryParse(data.Substring(1),System.Globalization.NumberStyles.AllowHexSpecifier,provider,out int res);
					break;
				case "ecl":
					valid = ecl.Contains(data);
					break;
				case "pid":
					valid = data.Length == 9 && Int32.TryParse(data,out int r);
					break;
			}
			return valid;
		}
	}
}