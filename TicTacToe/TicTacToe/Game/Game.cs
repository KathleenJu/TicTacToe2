using System;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public abstract class Game
    {
        public Board GameBoard { get; }
        public IGameRules GameRules { get; }
        public GameStatus GameStatus { get; protected set; }

        protected Game(Board gameBoard, IGameRules gameRules)
        {
            GameBoard = gameBoard;
            GameRules = gameRules;
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayMove(PlayerMove playerMove)
        {
            if (GameRules.CheckPlayMovePosition(playerMove, GameBoard))
            {
                GameBoard.UpdateBoard(playerMove);
                return true;
            }
            return false;
        }

        public Symbol? GetWinner()
        {
            if (GameStatus == GameStatus.OVER && GameRules.HasWinner(GameBoard)) // necessary to check if there is winner? should it return null?
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

        public abstract void StartGame(string welcomeMessage);

        public abstract PlayerMove GetPlayerMove();
    }
}