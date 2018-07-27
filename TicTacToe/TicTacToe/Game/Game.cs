using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public abstract class Game
    {
        public Board GameBoard { get; }
        public List<Player> GamePlayers { get; }
        public Player CurrentPlayer { get; protected set; }
        public IGameRules GameRules { get; }
        public GameStatus GameStatus { get; protected set; }

        protected Game(Board gameBoard, IGameRules gameRules)
        {
            GameBoard = gameBoard;
            GameRules = gameRules;
            GamePlayers = new List<Player>(); 
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayMove(PlayerMove playerMove)
        {
            if (GameRules.IsValidPlayMove(playerMove, GameBoard))
            {
                GameBoard.UpdateBoard(playerMove);
                return true;
            }
            throw new InvalidCoordinateException("Invalid move. Either coord is taken or out of the board range. \n");
        }

        public bool IsGameOver()
        {
            return GameRules.HasWinner(GameBoard) || IsDrawGame();
        }

        private bool IsDrawGame()
        {
            var fullBoard = GameBoard.PlayedMoves.Count() == GameBoard.BoardSize * GameBoard.BoardSize;
            return fullBoard;
        }
        
        public Player GetWinner()
        {
            return GameRules.HasWinner(GameBoard) ? GameBoard.PlayedMoves.Last().Player : null;
        }
        
        protected void EndGame()
        {
            GameStatus = GameStatus.OVER;
        }

        public abstract void StartGame(string welcomeMessage);

        public abstract PlayerMove GetPlayerMove();

        protected abstract void AddPlayersToGame();

        protected abstract void SetCurrentPlayer();
    }
}