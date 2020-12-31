using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day1
{
    public class Day1Resolver : IAdventResolver
    {
        private readonly IEnumerable<int> _values;

        public Day1Resolver(IEnumerable<int> values)
        {
            _values = values;
        }

        public object ResolvePartOne()
        {
            foreach(var value in _values)
            {
                Console.WriteLine($"Value: {value}");
                var maxValue = 2020 - value;
                var possibleValues = _values.Where(x => x <= maxValue);
                Console.WriteLine($"Possible values to 2020: [{string.Join(',', possibleValues)}]");
                foreach (var possibleValue in possibleValues)
                {
                    Console.WriteLine($"Possible value: {possibleValue}");
                    if (value + possibleValue == 2020)
                    {
                        Console.WriteLine($"Found: {value} + {possibleValue} = 2020");
                        return value * possibleValue;
                    }
                }
            }

            throw new Exception("You've failed");
        }

        public object ResolvePartTwo()
        {
            foreach (var value in _values)
            {
                Console.WriteLine($"Value: {value}");
                var firstMaxValue = 2020 - value;
                var secondPossibleValues = _values.Where(x => x <= firstMaxValue);
                Console.WriteLine($"Second possible values to 2020: [{string.Join(',', secondPossibleValues)}]");
                foreach (var secondPossibleValue in secondPossibleValues)
                {
                    Console.WriteLine($"Possible second value: {secondPossibleValue}");
                    var secondMaxValue = 2020 - value - secondPossibleValue;
                    var thirdPossibleValues = secondPossibleValues.Where(x => x <= secondMaxValue);
                    Console.WriteLine($"Third possible values to 2020: [{string.Join(',', thirdPossibleValues)}]");
                    foreach (var thirdPossibleValue in thirdPossibleValues)
                    {
                        Console.WriteLine($"Possible third value: {thirdPossibleValue}");
                        if (value + secondPossibleValue + thirdPossibleValue == 2020)
                        {
                            Console.WriteLine($"Found: {value} + {secondPossibleValue} + {thirdPossibleValue} = 2020");
                            return value * secondPossibleValue * thirdPossibleValue;
                        }
                    }
                }
            }

            throw new Exception("You've failed");
        }
    }
}
