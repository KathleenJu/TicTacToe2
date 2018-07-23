using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class TicTacToeRules : IGameRules
    {
        private readonly int NumberOfSymbolsInALineToWin = 3;

        public bool HasWinner(Board board)
        {
            var lastPlayedSymbol = board.PlayedMoves.Last().Symbol;
            var coordinates = board.PlayedMoves.Where(move => move.Symbol == lastPlayedSymbol)
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
            var isWinningRow = coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
            return isWinningRow;
        }

        private bool CheckForWinningColumn(List<Coordinates> coordinates)
        {
            var isWinningColumn = coordinates.GroupBy(coord => coord.Column).Select(columns => columns.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
            return  isWinningColumn;
        }

        private bool CheckForWinningPrimaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.Row == coord.Column).Distinct().Count() == NumberOfSymbolsInALineToWin;
            return isWinningDiagonalLine;
        }

        private bool CheckForWinningSecondaryDiagonalLine(List<Coordinates> coordinates)
        {
            var isWinningDiagonalLine = coordinates.Where(coord => coord.Row + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin;
            return isWinningDiagonalLine;
        }
    }
}