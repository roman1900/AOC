﻿using System;
using System.IO;

namespace AOC
{
    class Program
    {
        static private int[] input1 = new int[] {
			1945,
2004,
1520,
1753,
1463,
1976,
1994,
1830,
1942,
1784,
1858,
1841,
1721,
1480,
1821,
1584,
978,
1530,
1278,
1827,
889,
1922,
1996,
1992,
1819,
1847,
2010,
2002,
210,
1924,
1482,
1451,
1867,
1364,
1578,
1623,
1117,
1594,
1476,
1879,
1797,
1952,
2005,
1734,
1898,
1880,
1330,
1854,
1813,
1926,
1686,
1286,
1808,
1876,
1366,
1995,
1632,
1699,
2001,
1365,
1343,
1979,
1868,
1815,
820,
1966,
1888,
1916,
1852,
1932,
1368,
1606,
1825,
1731,
1980,
1990,
1818,
1702,
1419,
1897,
1970,
1276,
1914,
1889,
1953,
1588,
1958,
1310,
1391,
1326,
1131,
1959,
1844,
1307,
1998,
1961,
1708,
1977,
1886,
1946,
1516,
1999,
1859,
1931,
1853,
1265,
1869,
1642,
1740,
1467,
1944,
1956,
1263,
1940,
1912,
1832,
1872,
1678,
1319,
1839,
1689,
1765,
1894,
1242,
1983,
1410,
1985,
1387,
1022,
1358,
860,
112,
1964,
1836,
1838,
1285,
1943,
1718,
1351,
760,
1925,
1842,
1921,
1967,
1822,
1978,
1837,
1378,
1618,
1266,
2003,
1972,
666,
1321,
1938,
1616,
1892,
831,
1865,
1314,
1571,
1806,
1225,
1882,
1454,
1257,
1381,
1284,
1907,
1950,
1887,
1492,
1934,
1709,
1315,
1574,
1794,
1576,
1883,
1864,
1981,
1317,
1397,
1325,
1620,
1895,
1485,
1828,
1803,
1715,
1374,
1251,
1460,
1863,
1581,
1499,
1933,
1982,
1809,
1812
		};
        static void Main(string[] args)
        {
            int[] result = Day1.TheNumber(2020,input1);
            Console.WriteLine($"{result[0]} * {result[1]} = {result[0] * result[1]}");
            Day1.TheTrips(2020,input1);

            string[] input2 = File.ReadAllLines("input-day2.txt");
            int Good=0;
            int Good2=0;
            for (int i = 0; i < input2.Length ; i++)
            {
                
                Good = Day2.ValidPassword(input2[i]) ? Good+1 : Good;
                Good2 = Day2.ValidPasswordAlt(input2[i]) ? Good2 + 1 : Good2;
            }
            Console.WriteLine($"{Good} valid passwords method 1.");
            Console.WriteLine($"{Good2} valid passwords method 2.");

            string[] map = File.ReadAllLines("input-day3.txt");
            long total = Day3.TreesHit(map,1,1) * Day3.TreesHit(map,3,1) * Day3.TreesHit(map,5,1) * Day3.TreesHit(map,7,1) * Day3.TreesHit(map,1,2);
            Console.WriteLine($"Hit {Day3.TreesHit(map,1,1)} trees");
            Console.WriteLine($"Hit {Day3.TreesHit(map,3,1)} trees");
            Console.WriteLine($"Hit {Day3.TreesHit(map,5,1)} trees");
            Console.WriteLine($"Hit {Day3.TreesHit(map,7,1)} trees");
            Console.WriteLine($"Hit {Day3.TreesHit(map,1,2)} trees");
            Console.WriteLine($"Total Trees: {total}");

            string[] input4 = File.ReadAllLines("input-day4.txt");
            long PC = Day4.PassportCount(input4,false);
            Console.WriteLine($"{PC} valid passports found");
            long vPC = Day4.PassportCount(input4,true);
            Console.WriteLine($"{vPC} validated passports found");
            string[] input5 = File.ReadAllLines("input-day5.txt");
            int maxSeatID = Day5.MaxSeatID(input5);
            Console.WriteLine($"The maximum seat ID is {maxSeatID}");
            int mySeat = Day5.MySeat(input5);
            Console.WriteLine($"My seat ID is {mySeat}");
        }
    }
}
