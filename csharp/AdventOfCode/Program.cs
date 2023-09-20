using AdventOfCode.Day01;
using AdventOfCode.Day02;
using AdventOfCode.Day03;
using AdventOfCode.Day04;
using AdventOfCode.Day05;
using AdventOfCode.Day06;
using AdventOfCode.Day07;
using AdventOfCode.Day08;
using AdventOfCode.Day09;
using AdventOfCode.Day10;
using AdventOfCode.Day11;
using AdventOfCode.Day12;
using AdventOfCode.Day13;
using AdventOfCode.Day14;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static string GetFile<T>() where T : IAdventResolver
        {
            using var reader = new StreamReader($"./2020/{typeof(T).Name.Replace("Resolver", string.Empty)}/Input.txt");
            return reader.ReadToEnd();
        }
    }
}
