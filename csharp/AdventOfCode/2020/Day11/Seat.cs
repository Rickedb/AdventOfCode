using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class Seat
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public char RawStatus { get; set; }
        public SeatStatus Status
        {
            get
            {
                return RawStatus switch
                {
                    'L' => SeatStatus.Empty,
                    '#' => SeatStatus.Occupied,
                    _ => SeatStatus.Floor,
                };
            }
            set
            {
                RawStatus = value switch
                {
                    SeatStatus.Empty => 'L',
                    SeatStatus.Occupied => '#',
                    _ => '.',
                };
            }
        }

        public List<Seat> AdjacentSeats { get; set; }

        public Seat(char status, int row, int column)
        {
            RawStatus = status;
            AdjacentSeats = new List<Seat>();
            Row = row;
            Column = column;
        }

        public Seat Clone()
        {
            return new Seat(RawStatus, Row, Column);
        }
    }
}
