using System.Collections.Generic;

namespace AdventOfCode2020.Day12
{
    public class ShipTwo
    {
        private Dictionary<CardinalDirections, long> _waypoints;
        public Dictionary<CardinalDirections, long> Travelled { get; }

        public ShipTwo()
        {
            _waypoints = new Dictionary<CardinalDirections, long>()
                {
                    { CardinalDirections.East, 10 },
                    { CardinalDirections.North, 1 },
                    { CardinalDirections.West, 0 },
                    { CardinalDirections.South, 0 }
                };
            Travelled = new Dictionary<CardinalDirections, long>()
                {
                    { CardinalDirections.East, 0 },
                    { CardinalDirections.North, 0 },
                    { CardinalDirections.West, 0 },
                    { CardinalDirections.South, 0 }
                };
        }

        public void ExecuteInstruction(string instruction)
        {
            var direction = instruction.Substring(0, 1);
            var degreesOrValue = int.Parse(instruction[1..]);

            switch (direction)
            {
                case "F":
                    Travelled[CardinalDirections.North] += _waypoints[CardinalDirections.North] * degreesOrValue;
                    Travelled[CardinalDirections.South] += _waypoints[CardinalDirections.South] * degreesOrValue;
                    Travelled[CardinalDirections.East] += _waypoints[CardinalDirections.East] * degreesOrValue;
                    Travelled[CardinalDirections.West] += _waypoints[CardinalDirections.West] * degreesOrValue;
                    break;
                case "L":
                    ChangeDirection(Directions.Left, degreesOrValue);
                    break;
                case "R":
                    ChangeDirection(Directions.Right, degreesOrValue);
                    break;
                case "N":
                    _waypoints[CardinalDirections.North] += degreesOrValue;
                    break;
                case "S":
                    _waypoints[CardinalDirections.South] += degreesOrValue;
                    break;
                case "E":
                    _waypoints[CardinalDirections.East] += degreesOrValue;
                    break;
                case "W":
                    _waypoints[CardinalDirections.West] += degreesOrValue;
                    break;
            }
        }

        private void ChangeDirection(Directions direction, int degrees)
        {
            var totalCardinalsToChange = degrees / 90;
            for (int i = 0; i < totalCardinalsToChange; i++)
            {
                var values = new Dictionary<CardinalDirections, long>(_waypoints);
                if(direction == Directions.Right)
                {
                    _waypoints[CardinalDirections.East] = values[CardinalDirections.North];
                    _waypoints[CardinalDirections.South] = values[CardinalDirections.East];
                    _waypoints[CardinalDirections.West] = values[CardinalDirections.South];
                    _waypoints[CardinalDirections.North] = values[CardinalDirections.West];
                }
                else
                {
                    _waypoints[CardinalDirections.East] = values[CardinalDirections.South];
                    _waypoints[CardinalDirections.North] = values[CardinalDirections.East];
                    _waypoints[CardinalDirections.West] = values[CardinalDirections.North];
                    _waypoints[CardinalDirections.South] = values[CardinalDirections.West];
                }
            }
        }
    }
}
