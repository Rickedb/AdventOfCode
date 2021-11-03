using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day12
{
    public class Day12Resolver : IAdventResolver
    {
        private readonly IEnumerable<string> _instructions;

        public Day12Resolver(IEnumerable<string> instructions)
        {
            _instructions = instructions;
        }

        public object ResolvePartOne()
        {
            var ship = new ShipOne();
            foreach(var instruction in _instructions)
            {
                ship.ExecuteInstruction(instruction);
            }

            var travelledEastWest = Math.Abs(ship.Travelled[CardinalDirections.East] - ship.Travelled[CardinalDirections.West]);
            var travelledNorthSouth = Math.Abs(ship.Travelled[CardinalDirections.North] - ship.Travelled[CardinalDirections.South]);

            var total = travelledNorthSouth + travelledEastWest;
            return total;
        }

        public object ResolvePartTwo()
        {
            var ship = new ShipTwo();
            foreach (var instruction in _instructions)
            {
                ship.ExecuteInstruction(instruction);
            }

            var travelledEastWest = Math.Abs(ship.Travelled[CardinalDirections.East] - ship.Travelled[CardinalDirections.West]);
            var travelledNorthSouth = Math.Abs(ship.Travelled[CardinalDirections.North] - ship.Travelled[CardinalDirections.South]);

            var total = travelledNorthSouth + travelledEastWest;
            return total;
        }
    }
}
