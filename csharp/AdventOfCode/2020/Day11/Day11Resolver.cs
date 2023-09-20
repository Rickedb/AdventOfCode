using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day11
{
    public class Day11Resolver : IAdventResolver
    {
        private Seat[,] seatsMap;
        private readonly IList<string> _inputSeats;
        private readonly int _columns;
        private readonly int _rows;

        public Day11Resolver(IList<string> seatsRows)
        {
            _columns = seatsRows[0].Length;
            _rows = seatsRows.Count;
            _inputSeats = seatsRows;
        }

        public object ResolvePartOne()
        {
            var mapper = new SeatMapper(_rows, _columns, true);
            seatsMap = Parse(mapper, _inputSeats);
            var totalOccupied = GetTotalOccupied(mapper, 4);
            return totalOccupied;
        }

        public object ResolvePartTwo()
        {
            var mapper = new SeatMapper(_rows, _columns, false);
            seatsMap = Parse(mapper, _inputSeats);
            var totalOccupied = GetTotalOccupied(mapper, 5);
            return totalOccupied;
        }

        private int GetTotalOccupied(SeatMapper mapper, int maxOccupiedSeats)
        {
            bool equal;
            do
            {
                equal = true;
                var newMap = GenerateNextMap(maxOccupiedSeats);

                for (int row = 0; row < _rows; row++)
                {
                    for (int column = 0; column < _columns; column++)
                    {
                        if (newMap[row, column].Status != seatsMap[row, column].Status)
                        {
                            equal = false;
                            break;
                        }
                    }

                    if (!equal)
                    {
                        break;
                    }
                }

                seatsMap = mapper.MapAdjacentSeats(newMap);
            } while (!equal);

            var totalOccupied = seatsMap.Cast<Seat>().Count(x => x.Status == SeatStatus.Occupied);
            return totalOccupied;
        }

        private Seat[,] GenerateNextMap(int maxOccupiedSeats)
        {
            var map = new Seat[_rows, _columns];
            foreach (var seat in seatsMap)
            {
                var clone = seat.Clone();
                if (seat.Status == SeatStatus.Empty && !seat.AdjacentSeats.Any(x => x.Status == SeatStatus.Occupied))
                {
                    clone.Status = SeatStatus.Occupied;
                }
                else if (seat.Status == SeatStatus.Occupied && seat.AdjacentSeats.Count(x => x.Status == SeatStatus.Occupied) > maxOccupiedSeats - 1)
                {
                    clone.Status = SeatStatus.Empty;
                }

                map[seat.Row, seat.Column] = clone;
            }

            return map;
        }


        private Seat[,] Parse(SeatMapper mapper, IList<string> seatsRows)
        {
            var map = new Seat[_rows, _columns];
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    map[row, column] = new Seat(seatsRows[row][column], row, column);
                }
            }

            return mapper.MapAdjacentSeats(map);
        }
    }
}
