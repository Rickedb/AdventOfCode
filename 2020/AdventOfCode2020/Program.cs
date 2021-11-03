using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Day03;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Day05;
using AdventOfCode2020.Day06;
using AdventOfCode2020.Day07;
using AdventOfCode2020.Day08;
using AdventOfCode2020.Day09;
using AdventOfCode2020.Day10;
using AdventOfCode2020.Day11;
using AdventOfCode2020.Day12;
using AdventOfCode2020.Day13;
using AdventOfCode2020.Day14;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolvers = new IAdventResolver[]
            {
                //new Day01Resolver(GetFile<Day01Resolver>().Split("\r\n").Select(int.Parse)),
                //new Day02Resolver(GetFile<Day02Resolver>().Split("\r\n")),
                //new Day03Resolver(GetFile<Day03Resolver>().Split("\r\n")),
                //new Day04Resolver(GetFile<Day04Resolver>()),
                //new Day05Resolver(GetFile<Day05Resolver>().Split("\r\n")),
                //new Day06Resolver(GetFile<Day06Resolver>()),
                //new Day07Resolver(GetFile<Day07Resolver>().Split("\r\n")),
                //new Day08Resolver(GetFile<Day08Resolver>().Split("\r\n")),
                //new Day09Resolver(GetFile<Day09Resolver>().Split("\r\n").Select(long.Parse)),
                //new Day10Resolver(GetFile<Day10Resolver>().Split("\r\n").Select(int.Parse)),
                //new Day11Resolver(GetFile<Day11Resolver>().Split("\r\n").ToList()),
                //new Day12Resolver(GetFile<Day12Resolver>().Split("\r\n")),
                //new Day13Resolver(GetFile<Day13Resolver>().Split("\r\n")),
                new Day14Resolver(GetFile<Day14Resolver>().Split("\r\n")),
            };

            foreach(var resolver in resolvers)
            {
                var resolverName = resolver.GetType().Name;
                var result = resolver.ResolvePartOne();
                Console.WriteLine($"[{resolverName} - Part One] => Result: {result}");

                result = resolver.ResolvePartTwo();
                Console.WriteLine($"[{resolverName} - Part Two] => Result: {result}");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static string GetFile<T>() where T : IAdventResolver
        {
            using var reader = new StreamReader($"./{typeof(T).Name.Replace("Resolver", string.Empty)}/Input.txt");
            return reader.ReadToEnd();
        }
    }
}
