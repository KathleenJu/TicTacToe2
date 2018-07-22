using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class TicTacToeRules : IGameRules
    {
        private readonly int NumberOfSymbolsInALineToWin = 3;
        
        public TicTacToeRules()
        {
        } 
        
        public bool HasWinner(TicTacToeBoard board)
        {
            var playedMoves = board.PlayedMoves;
            var lastPlayedSymbol = playedMoves.Last().Symbol;
            var coordinates = playedMoves.Where(move => move.Symbol == lastPlayedSymbol)
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
        
//        public Symbol? GetWinner()
//        {
//            if (HasWinner())
//            {
//                var lastPlayedSymbol = PlayedMoves.Last().Symbol;
//                return lastPlayedSymbol;
//            }
//            return null;
//        }
//
//        public bool IsGameOver()
//        {
//            if (GetWinner() != null)
//            {
////                GameStatus = GameStatus.OVER;
//                return true;
//            }
//            var isDrawGame = IsDrawGame();
//            return isDrawGame;
//        }
//
//        private bool IsDrawGame()
//        {
//            var fullBoard = PlayedMoves.Count == BoardSize * BoardSize;
//            if (fullBoard)
//            {
////                GameStatus = GameStatus.OVER;
//                return true;
//            }
//            return false;
//        }

    }
}