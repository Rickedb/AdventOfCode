using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Xml.Schema;

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
                var rowPosition = CalculatePosition(0, seat.Substring(0, 7), 'F', 0, 127);
                var columnPosition = CalculatePosition(0, seat.Substring(7, 3), 'L', 0, 7);

                var id = rowPosition * 8 + columnPosition;
                if(id > highestId)
                {
                    highestId = id;
                }
            }

            return highestId;
        }

        public object ResolvePartTwo()
        {
            throw new NotImplementedException();
        }

        private int CalculatePosition(int index, string evaluationString, char firstHalfCharacter, int minimum, int maximum)
        {
            var character = evaluationString[index];
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

            if (index + 1 < evaluationString.Length)
            {
                return CalculatePosition(index + 1, evaluationString, firstHalfCharacter, minimum, maximum);
            }

            return obtainedValue;
        }

        //private int CalculatePosition(string evaluationString, char firstHalfCharacter, char lastHalfCharacter, int totalPositions)
        //{
        //    int minimum = 0;
        //    int maximum = totalPositions;
        //    foreach (var character in evaluationString)
        //    {
        //        var half = (maximum - minimum) / 2;
        //        if (character == firstHalfCharacter)
        //        {
        //            maximum = minimum + half;
        //        }
        //        else if (character == lastHalfCharacter)
        //        {
        //            minimum = maximum - half;
        //        }
        //        else
        //        {
        //            //invalid string
        //            return -1;
        //        }
        //    }

        //    return maximum;
        //}
    }
}
