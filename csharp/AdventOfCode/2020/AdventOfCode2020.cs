using AdventOfCode.Day14;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2020
{
    internal class AdventOfCode2020
    {
        public void Solve()
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
                new Day14Resolver(AdventInput.ReadFile<Day14Resolver>(2020, "\r\n")),
            };

            foreach (var resolver in resolvers)
            {
                var resolverName = resolver.GetType().Name;
                var result = resolver.ResolvePartOne();
                Console.WriteLine($"[{resolverName} - Part One] => Result: {result}");

                result = resolver.ResolvePartTwo();
                Console.WriteLine($"[{resolverName} - Part Two] => Result: {result}");
            }

        }
    }
}
