using System.Data.Common;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class TicTacToeGame : Game
    {
        public TicTacToeGame(Board gameBoard, IGameRules gameRules) : base(gameBoard, gameRules)
        {
        }

        public void PlayMove(PlayerMove playerMove)
        {
            GameBoard.UpdateBoard(playerMove);
        }

        public Symbol? GetWinner()
        {
            if (GameStatus == GameStatus.OVER && GameRules.HasWinner(GameBoard)) // necessary to check if there is winner ?
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