using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public TicTacToeBoard(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {
        }

        public override bool IsWinningMove(PlayerMove playerMove)
        {
            var coordinates = PlayerMoves.Where(move => move.Symbol == playerMove.Symbol)
                .Select(move => move.GetCoordinates()).ToList();
            var hasWinningLine = new List<bool>();

            hasWinningLine.Add(CheckForWinningRow(coordinates));
            hasWinningLine.Add(CheckForWinningColumn(coordinates));
            hasWinningLine.Add(CheckForWinningSecondaryDiagonalLine(coordinates));
            hasWinningLine.Add(CheckForWinningPrimaryDiagonalLine(coordinates));

            return hasWinningLine.Any(x => x);
        }

        private bool CheckForWinningRow(List<Coordinates> coordinates)
        {
            var winningRow = new List<bool>();
            for (var row = 0; row < BoardHeight; row++)
            {
                winningRow.Add(coordinates.Where(coord => coord.GetRow() == row)
                                   .Distinct()
                                   .Count() == BoardHeight);
            }

            return winningRow.Any(x => x);
        }

        private bool CheckForWinningColumn(List<Coordinates> coordinates)
        {
            var winningColumn = new List<bool>();
            for (var column = 0; column < BoardHeight; column++)
            {
                winningColumn.Add(coordinates.Where(coord => coord.GetColumn() == column)
                                      .Distinct()
                                      .Count() == BoardHeight);
            }

            return winningColumn.Any(x => x);
        }

        private bool CheckForWinningPrimaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.GetRow() == coord.GetColumn()).Distinct().Count() == BoardHeight;
            return isWinningDiagonalLine;
        }

        private bool CheckForWinningSecondaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.GetRow() + coord.GetColumn() == BoardHeight - 1).Distinct().Count() == BoardHeight;
            return isWinningDiagonalLine;
        }
    }
}