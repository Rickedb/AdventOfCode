using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using AdventOfCode2020.Day3;
using AdventOfCode2020.Day4;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunDay1();
            //RunDay2();
            //RunDay3();
            RunDay4();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


        static void RunDay1()
        {
            var reader = new StreamReader("./Day1/Input.txt");
            var input = reader.ReadToEnd().Split("\r\n").Select(x => int.Parse(x));

            var resolver = new Day1Resolver(input);
            var result = resolver.ResolvePartOne();
            Console.WriteLine($"[{nameof(Day1Resolver)} - Part One] => Result: {result}");

            result = resolver.ResolvePartTwo();
            Console.WriteLine($"[{nameof(Day1Resolver)} - Part Two] => Result: {result}");
        }

        static void RunDay2()
        {
            var reader = new StreamReader("./Day2/Input.txt");
            var input = reader.ReadToEnd().Split("\r\n");

            var resolver = new Day2Resolver(input);
            var result = resolver.ResolvePartOne();
            Console.WriteLine($"[{nameof(Day2Resolver)} - Part One] => Result: {result}");

            result = resolver.ResolvePartTwo();
            Console.WriteLine($"[{nameof(Day2Resolver)} - Part Two] => Result: {result}");
        }

        static void RunDay3()
        {
            var reader = new StreamReader("./Day3/Input.txt");
            var input = reader.ReadToEnd().Split("\r\n");

            var resolver = new Day3Resolver(input);
            var result = resolver.ResolvePartOne();
            Console.WriteLine($"[{nameof(Day3Resolver)} - Part One] => Result: {result}");

            result = resolver.ResolvePartTwo();
            Console.WriteLine($"[{nameof(Day3Resolver)} - Part Two] => Result: {result}");
        }

        static void RunDay4()
        {
            var reader = new StreamReader("./Day4/Input.txt");
            var input = reader.ReadToEnd();

            var resolver = new Day4Resolver(input);
            var result = resolver.ResolvePartOne();
            Console.WriteLine($"[{nameof(Day4Resolver)} - Part One] => Result: {result}");

            result = resolver.ResolvePartTwo();
            Console.WriteLine($"[{nameof(Day4Resolver)} - Part Two] => Result: {result}");
        }
    }
}
