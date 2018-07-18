using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public readonly List<List<Coordinates>> WinningLines = new List<List<Coordinates>>();

        public TicTacToeBoard(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {
        }

        public List<Coordinates> HasWinner(PlayerMove playerMove)
        {
            var winningHorizontalLine = new List<Coordinates>();
            for (var row = 1; row < BoardHeight + 1; row++)
            {
                WinningLines.Add(PlayedCoordinates.Select(move => move.GetCoordinates())
                    .Where(coord => coord.GetRow() == row)
                    .ToList());
            }

            return winningHorizontalLine;
        }
    }
}