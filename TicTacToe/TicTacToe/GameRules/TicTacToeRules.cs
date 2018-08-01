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
            var lastPlayer = board.PlayedMoves.Last().Player;
            var coordinates = board.PlayedMoves.Where(move => move.Player == lastPlayer)
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

        private bool CheckForWinningRow(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
        }

        private bool CheckForWinningColumn(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.GroupBy(coord => coord.Column).Select(columns => columns.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
        }

        private bool CheckForWinningPrimaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row == coord.Column).Distinct().Count() == NumberOfSymbolsInALineToWin;
        }

        private bool CheckForWinningSecondaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin;
        }
    }
}