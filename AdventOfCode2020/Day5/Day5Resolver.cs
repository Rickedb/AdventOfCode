using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day5
{
    public class Day5Resolver : IAdventResolver
    {
        private readonly IEnumerable<string> _seats;

        public Day5Resolver(IEnumerable<string> seats)
        {
            _seats = seats;
        }

        public object ResolvePartOne()
        {
            int highestId = 0;
            foreach (var seat in _seats)
            {
                var row = CalculatePosition(0, seat.Substring(0, 7), 'F', 0, 127);
                var column = CalculatePosition(0, seat.Substring(7, 3), 'L', 0, 7);

                var id = CalculateId(row, column);
                if (id > highestId)
                {
                    highestId = id;
                }
            }

            return highestId;
        }

        public object ResolvePartTwo()
        {
            var seatIds = new List<int>();
            foreach (var seat in _seats)
            {
                var row = CalculatePosition(0, seat.Substring(0, 7), 'F', 0, 127);
                var column = CalculatePosition(0, seat.Substring(7, 3), 'L', 0, 7);
                var id = CalculateId(row, column);
                seatIds.Add(id);
            }

            var firstId = seatIds.Min();
            var lastId = seatIds.Max();


            var mySideSeat = seatIds.First(x => x > firstId && x < lastId && (!seatIds.Contains(x + 1)));
            var mySeat = mySideSeat + 1;
            return mySeat;
        }

        private int CalculatePosition(int characterIndex, string boardingPass, char firstHalfCharacter, int minimum, int maximum)
        {
            var character = boardingPass[characterIndex];
            var half = (maximum - minimum) / 2;

            int obtainedValue;
            if (character == firstHalfCharacter)
            {
                obtainedValue = maximum = minimum + half;
            }
            else
            {
                obtainedValue = minimum = maximum - half;
            }

            if (characterIndex + 1 < boardingPass.Length)
            {
                return CalculatePosition(characterIndex + 1, boardingPass, firstHalfCharacter, minimum, maximum);
            }

            return obtainedValue;
        }

        private int CalculateId(int row, int column) => row * 8 + column;

    }
}
