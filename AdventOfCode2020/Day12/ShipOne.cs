using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day12
{
    public class ShipOne
    {
        public Dictionary<CardinalDirections, int> Travelled { get; }

        public CardinalDirections CurrentFaceDirection { get; private set; }

        public ShipOne()
        {
            Travelled = new Dictionary<CardinalDirections, int>()
                {
                    { CardinalDirections.East, 0 },
                    { CardinalDirections.North, 0 },
                    { CardinalDirections.West, 0 },
                    { CardinalDirections.South, 0 }
                };
            CurrentFaceDirection = CardinalDirections.East;
        }

        public void ExecuteInstruction(string instruction)
        {
            var direction = instruction.Substring(0, 1);
            var degreesOrValue = int.Parse(instruction[1..]);

            switch (direction)
            {
                case "F":
                    Travelled[CurrentFaceDirection] += degreesOrValue;
                    break;
                case "L":
                    ChangeDirection(Directions.Left, degreesOrValue);
                    break;
                case "R":
                    ChangeDirection(Directions.Right, degreesOrValue);
                    break;
                case "N":
                    Travelled[CardinalDirections.North] += degreesOrValue;
                    break;
                case "S":
                    Travelled[CardinalDirections.South]+= degreesOrValue;
                    break;
                case "E":
                    Travelled[CardinalDirections.East] += degreesOrValue;
                    break;
                case "W":
                    Travelled[CardinalDirections.West] += degreesOrValue;
                    break;
            }
        }

        private void SwapCardinalValues(Directions directions, int degrees)
        {

        }

        private void ChangeDirection(Directions direction, int degrees)
        {
            var totalCardinalsToChange = degrees / 90;
            int intDirection;
            if (direction == Directions.Right)
            {
                intDirection = (int)CurrentFaceDirection + totalCardinalsToChange;
                if (intDirection > (int)CardinalDirections.North)
                {
                    intDirection = intDirection - (int)CardinalDirections.North - 1;
                }
            }
            else
            {
                intDirection = (int)CurrentFaceDirection - totalCardinalsToChange;
                if (intDirection < (int)CardinalDirections.East)
                {
                    intDirection = 4 - Math.Abs(intDirection);
                }
            }

            CurrentFaceDirection = (CardinalDirections)intDirection;
        }
    }
}
