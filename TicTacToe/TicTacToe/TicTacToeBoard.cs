using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public TicTacToeBoard(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {
        }

        public override bool IsWinningMove(PlayerMove playerMove)
        {
            var coordinates = PlayerMoves.Where(move => move.GetSymbol() == playerMove.GetSymbol())
                .Select(move => move.GetCoordinates())
                .ToList();
            var hasWinningLine = new List<bool>
            {
                CheckForWinningRow(coordinates),
                CheckForWinningColumn(coordinates),
                CheckForWinningSecondaryDiagonalLine(coordinates),
                CheckForWinningPrimaryDiagonalLine(coordinates)
            };

            return hasWinningLine.Contains(true);
        }

        private bool CheckForWinningRow(List<Coordinates> coordinates)
        {
            var isWinningRow = coordinates.GroupBy(coord => coord.GetRow()).Select(rows => rows.Count()).Any(count => count == BoardHeight);
            return isWinningRow;
        }

        private bool CheckForWinningColumn(List<Coordinates> coordinates)
        {
            var isWinningColumn = coordinates.GroupBy(coord => coord.GetColumn()).Select(columns => columns.Count()).Any(count => count == BoardHeight);
            return  isWinningColumn;
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