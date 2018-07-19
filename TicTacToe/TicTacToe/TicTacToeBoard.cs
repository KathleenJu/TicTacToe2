using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public TicTacToeBoard(int boardSize) : base(boardSize)
        {
        }

        public override bool HasWinner()
        {
            var lastPlayedSymbol = PlayedMoves.Last().Symbol;
            var coordinates = PlayedMoves.Where(move => move.Symbol == lastPlayedSymbol)
                .Select(move => move.Coordinates)
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
            var isWinningRow = coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == BoardSize);
            return isWinningRow;
        }

        private bool CheckForWinningColumn(List<Coordinates> coordinates)
        {
            var isWinningColumn = coordinates.GroupBy(coord => coord.Column).Select(columns => columns.Count()).Any(count => count == BoardSize);
            return  isWinningColumn;
        }

        private bool CheckForWinningPrimaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.Row == coord.Column).Distinct().Count() == BoardSize;
            return isWinningDiagonalLine;
        }

        private bool CheckForWinningSecondaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.Row + coord.Column == BoardSize - 1).Distinct().Count() == BoardSize;
            return isWinningDiagonalLine;
        }
    }
}