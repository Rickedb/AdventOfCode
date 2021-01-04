using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day9
{
    public class Day9Resolver : IAdventResolver
    {
        private readonly List<long> _data;

        public Day9Resolver(IEnumerable<long> data)
        {
            _data = data.ToList();
        }

        public object ResolvePartOne()
        {
            var invalidNumber = GetFirstInvalidNumber(25);
            return invalidNumber;
        }

        public object ResolvePartTwo()
        {
            var invalidNumber = GetFirstInvalidNumber(25);
            for (int i = 0; i < _data.Count; i++)
            {
                var setOfNumbers = 2;
                long sumOfNumbers;
                do
                {
                    var selectedNumbers = _data.Skip(i).Take(setOfNumbers);
                    sumOfNumbers = selectedNumbers.Sum();
                    if (sumOfNumbers == invalidNumber)
                    {
                        var encryptionWeakness = selectedNumbers.Min() + selectedNumbers.Max();
                        return encryptionWeakness;
                    }
                    setOfNumbers++;
                }
                while (sumOfNumbers < invalidNumber);
            }

            throw new Exception("Something failed in here");
        }

        private long GetFirstInvalidNumber(int index)
        {
            var numberToTest = _data[index];

            var preamble = _data.Skip(index - 25).Take(25);
            foreach (var firstNumber in preamble)
            {
                foreach (var secondNumber in preamble.Where(x => x != firstNumber))
                {
                    if (firstNumber + secondNumber == numberToTest)
                    {
                        return GetFirstInvalidNumber(index + 1);
                    }
                }
            }

            return numberToTest;
        }
    }
}
