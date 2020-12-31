using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day3
{
    public class Day3Resolver : IAdventResolver
    {
        private const char TREE = '#';

        private readonly string[] _map;
        private readonly int _mapWidth;
        private readonly int _mapHeight;

        public Day3Resolver(IEnumerable<string> map)
        {
            _map = map.ToArray(); //better to work with array in this case
            _mapWidth = _map[0].Length;
            _mapHeight = _map.Length;
        }

        public object ResolvePartOne()
        {
            var posX = 0;
            var posY = 0;
            var XIncrement = 3;
            var YIncrement = 1;

            var totalTrees = 0;
            while(posY < _map.Length)
            {
                posX += XIncrement;
                posY += YIncrement;

                if(posX > _mapWidth - 1)
                {
                    posX -= _mapWidth;
                }

                if (_map[posY][posX] == TREE)
                {
                    totalTrees++;
                }
                
                if(posY >= _mapHeight - 1)
                {
                    break;
                }
            }

            return totalTrees;
        }

        public object ResolvePartTwo()
        {
            throw new NotImplementedException();
        }
    }
}
