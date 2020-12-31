using AdventOfCode2020.Day1;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDay1();
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
    }
}
