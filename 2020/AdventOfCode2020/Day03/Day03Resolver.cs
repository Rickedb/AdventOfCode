using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public class Day03Resolver : IAdventResolver
    {
        private const char TREE = '#';

        private readonly string[] _map;
        private readonly int _mapWidth;
        private readonly int _mapHeight;

        public Day03Resolver(IEnumerable<string> map)
        {
            _map = map.ToArray(); //better to work with array in this case
            _mapWidth = _map[0].Length;
            _mapHeight = _map.Length;
        }

        public object ResolvePartOne()
        {
            var totalTrees = GetTotalTrees(3 ,1);
            return totalTrees;
        }

        public object ResolvePartTwo()
        {
            var results = new long[] 
            {
                 GetTotalTrees(1, 1),
                 GetTotalTrees(3, 1),
                 GetTotalTrees(5, 1),
                 GetTotalTrees(7, 1),
                 GetTotalTrees(1, 2)
            };

            var treesMultiplied = results.Aggregate((ac, x) => ac * x);
            return treesMultiplied;
        }

        private int GetTotalTrees(int xIncrement, int yIncrement)
        {
            var posX = 0;
            var posY = 0;

            var totalTrees = 0;
            while (posY < _map.Length)
            {
                posX += xIncrement;
                posY += yIncrement;

                if (posX > _mapWidth - 1)
                {
                    posX -= _mapWidth;
                }

                if (_map[posY][posX] == TREE)
                {
                    totalTrees++;
                }

                if (posY >= _mapHeight - 1)
                {
                    break;
                }
            }

            return totalTrees;
        }
    }
}
