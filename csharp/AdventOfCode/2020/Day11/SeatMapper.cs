using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day11
{
    public class SeatMapper
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly bool _onlyCloseAdjacent;

        public SeatMapper(int rows, int columns, bool onlyCloseAdjacent)
        {
            _rows = rows;
            _columns = columns;
            _onlyCloseAdjacent = onlyCloseAdjacent;
        }

        public Seat[,] MapAdjacentSeats(Seat[,] seats)
        {
            foreach (var seat in seats)
            {
                seat.AdjacentSeats.Clear();
            }

            return _onlyCloseAdjacent ? MapOnlyCloseAdjacentSeats(seats) : MapVisibleAdjacentSeats(seats);
        }

        private Seat[,] MapVisibleAdjacentSeats(Seat[,] seats)
        {
            var elligibleSeats = seats.Cast<Seat>().Where(x => x.Status != SeatStatus.Floor);
            foreach (var seat in elligibleSeats)
            {
                var visibleSeats = new Seat[]
                {
                    FindVisible(seat, seats, 0, 1, (pair) => pair.Column < _columns - 1), //Right
                    FindVisible(seat, seats, 0, -1, (pair) => pair.Column > 0), //Left
                    FindVisible(seat, seats, 1, 0, (pair) => pair.Row < _rows - 1), //Down
                    FindVisible(seat, seats, -1, 0, (pair) => pair.Row > 0), //Up
                    FindVisible(seat, seats, -1, -1, (pair) => pair.Row > 0 && pair.Column > 0), //Up Left
                    FindVisible(seat, seats, -1, 1, (pair) => pair.Row > 0 && pair.Column < _columns - 1), //Up Right
                    FindVisible(seat, seats, 1, -1, (pair) => pair.Row < _rows - 1 && pair.Column > 0), //Down Left
                    FindVisible(seat, seats, 1, 1, (pair) =>  pair.Row < _rows - 1 && pair.Column < _columns - 1) //Down Right
                };

                seat.AdjacentSeats.AddRange(visibleSeats.Where(x => x != null));
            }

            return seats;
        }

        private Seat FindVisible(Seat seat, Seat[,] seats, int rowIncrementer, int columnIncrementer, Func<(int Row, int Column), bool> validator)
        {
            int column = seat.Column;
            int row = seat.Row;
            while (validator((row, column)))
            {
                column += columnIncrementer;
                row += rowIncrementer;

                var visibleSeat = seats[row, column];
                if (visibleSeat.Status == SeatStatus.Occupied || visibleSeat.Status == SeatStatus.Empty)
                {
                    return visibleSeat;
                }
            }

            return null;
        }

        private Seat[,] MapOnlyCloseAdjacentSeats(Seat[,] seats)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    var seat = seats[row, column];
                    if(seat.Status == SeatStatus.Floor)
                    {
                        continue;
                    }

                    if (row == 0)
                    {
                        if (column == 0)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row, column + 1], // right
                                seats[row + 1, column + 1] //bottom right
                            });
                        }
                        else if (column == _columns - 1)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row, column - 1], // left
                                seats[row + 1, column - 1] // bottom left
                            });
                        }
                        else
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row, column - 1], // left
                                seats[row, column + 1], // right
                                seats[row + 1, column + 1], //bottom right
                                seats[row + 1, column - 1] // bottom left
                            });
                        }
                    }
                    else if (row == _rows - 1)
                    {
                        if (column == 0)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row - 1, column], //above
                                seats[row, column + 1], // right
                                seats[row - 1, column + 1]// up right
                            });
                        }
                        else if (column == _columns - 1)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row - 1, column], //above
                                seats[row, column - 1], //left
                                seats[row - 1, column - 1] // up left
                            });
                        }
                        else
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row - 1, column], //above
                                seats[row, column - 1], // left
                                seats[row, column + 1], // right
                                seats[row - 1, column + 1], //up right
                                seats[row - 1, column - 1] //up left
                            });
                        }
                    }
                    else
                    {
                        if (column == 0)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row - 1, column], //above
                                seats[row, column + 1], // right
                                seats[row - 1, column + 1], // up right
                                seats[row + 1, column + 1]// bottom right
                            });
                        }
                        else if (column == _columns - 1)
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row - 1, column], //above
                                seats[row, column - 1], // left
                                seats[row - 1, column - 1], // up left
                                seats[row + 1, column - 1]// bottom left
                            });
                        }
                        else
                        {
                            seat.AdjacentSeats.AddRange(new Seat[] {
                                seats[row + 1, column], //below
                                seats[row - 1, column], //above
                                seats[row, column - 1], // left
                                seats[row, column + 1], // right
                                seats[row - 1, column + 1], //up right
                                seats[row - 1, column - 1], //up left
                                seats[row + 1, column + 1], // bottom right
                                seats[row + 1, column - 1]// bottom left
                            });
                        }
                    }
                }
            }

            return seats;
        }
    }
}
