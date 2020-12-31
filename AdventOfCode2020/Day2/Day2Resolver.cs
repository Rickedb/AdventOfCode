using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day2
{
    public class Day2Resolver : IAdventResolver
    {
        private readonly IEnumerable<string> _passwordsCombinations;

        public Day2Resolver(IEnumerable<string> passwordCombinations)
        {
            _passwordsCombinations = passwordCombinations;
        }

        public object ResolvePartOne()
        {
            int totalValidPasswords = 0;
            foreach(var combination in _passwordsCombinations)
            {
                var (Password, Character, AtLeastRepeat, MaxRepeatTimes) = ParseCombination(combination);

                var totalCharacterCount = Password.Count(x => x == Character);
                if (totalCharacterCount >= AtLeastRepeat && totalCharacterCount <= MaxRepeatTimes)
                {
                    totalValidPasswords++;
                }
            }

            return totalValidPasswords;
        }

        public object ResolvePartTwo()
        {
            throw new NotImplementedException();
        }

        private (string Password, char Character, int AtLeast, int MaxTimes) ParseCombination(string combination)
        {
            var splittedCombination = combination.Split(':');
            var validation = splittedCombination[0];
            var password = splittedCombination[1];

            var splittedValidation = validation.Split(' ');
            var range = splittedValidation[0];
            var character = splittedValidation[1];

            var splittedRange = range.Split('-');
            var atLeast = int.Parse(splittedRange[0]);
            var maxTimes = int.Parse(splittedRange[1]);

            return (password, character[0], atLeast, maxTimes);
        }
    }
}
