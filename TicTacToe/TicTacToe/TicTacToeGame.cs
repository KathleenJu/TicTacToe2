using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TicTacToeBoard GameBoard;
        private readonly TicTacToeRules GameRules;
        private GameStatus GameStatus;

        public TicTacToeGame(TicTacToeBoard gameBoard, TicTacToeRules gameRules)
        {
            GameBoard = gameBoard;
            GameRules = gameRules;
            GameStatus = GameStatus.PLAYING;
        }

        public Symbol? GetWinner()
        {
            if (GameStatus == GameStatus.OVER && GameRules.HasWinner(GameBoard))
            {
                var lastPlayedSymbol = GameBoard.PlayedMoves.Last().Symbol;
                return lastPlayedSymbol;
            }
            return null;
        }

        public bool IsGameOver()
        {
            if (GameRules.HasWinner(GameBoard))
            {
                GameStatus = GameStatus.OVER;
                return true;
            }
            var isDrawGame = IsDrawGame();
            return isDrawGame;
        }

        private bool IsDrawGame()
        {
            var fullBoard = GameBoard.PlayedMoves.Count == GameBoard.BoardSize * GameBoard.BoardSize;
            if (fullBoard)
            {
                GameStatus = GameStatus.OVER;
                return true;
            }
            return false;
        }
    }
}