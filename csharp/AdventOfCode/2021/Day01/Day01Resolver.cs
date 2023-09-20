using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    internal class Day01Resolver : IAdventResolver
    {
        private readonly string[] _calories;

        public Day01Resolver(string[] calories)
        {
            _calories = calories;
        }

        public object ResolvePartOne()
        {
            var list = CalculateElvesCalories();
            return list.Max();
        }

        public object ResolvePartTwo()
        {
            var list = CalculateElvesCalories();
            var top3 = list.OrderByDescending(x => x).Take(3);
            return top3.Sum();
        }

        private List<int> CalculateElvesCalories()
        {
            var currentElf = 0;
            var list = new List<int>() { 0 };
            for (int i = 0; i < _calories.Length; i++)
            {
                var row = _calories[i];
                if (string.IsNullOrEmpty(row))
                {
                    list.Add(0);
                    currentElf++;
                    continue;
                }

                list[currentElf] += int.Parse(row);
            }

            return list;
        }
    }
}
