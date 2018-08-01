using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public abstract class Game
    {
        public Board GameBoard { get; private set; }
        public List<Player> GamePlayers { get; }
        public Player CurrentPlayer { get; protected set; }
        public IGameRules GameRules { get; }
        public GameStatus GameStatus { get; protected set; }

        protected Game(IGameRules gameRules)
        {
            GameRules = gameRules;
            GameBoard = new Board();
            GamePlayers = new List<Player>();
            GameStatus = GameStatus.PLAYING;
        }

        public void PlayMove(PlayerMove playerMove)
        {
            GameBoard.UpdateBoard(playerMove);
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

        protected void SetGameBoard(int boardSize)
        {
            GameBoard = new Board(boardSize);
        }

        public abstract void StartGame(string welcomeMessage);

        protected abstract PlayerMove GetPlayerMove();

        protected abstract void AddPlayersToGame();

        protected abstract void SetCurrentPlayer();

        protected abstract int GetBoardSize();
    }
}