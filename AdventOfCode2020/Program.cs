using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using AdventOfCode2020.Day3;
using AdventOfCode2020.Day4;
using AdventOfCode2020.Day5;
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
                new Day1Resolver(GetFile<Day1Resolver>().Split("\r\n").Select(x => int.Parse(x))),
                new Day2Resolver(GetFile<Day2Resolver>().Split("\r\n")),
                new Day3Resolver(GetFile<Day3Resolver>().Split("\r\n")),
                new Day4Resolver(GetFile<Day4Resolver>()),
                new Day5Resolver(GetFile<Day5Resolver>().Split("\r\n")),
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
            using var reader = new StreamReader($".{typeof(T).Name.Replace("Resolver", string.Empty)}/Input.txt");
            return reader.ReadToEnd();
        }
    }
}
