using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
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
            return false;
        }

        public bool IsGameOver()
        {
            if (GameRules.HasWinner(GameBoard) || IsDrawGame())
            {
                GameStatus = GameStatus.OVER;
                return true;
            }

            return false;
        }

        private bool IsDrawGame()
        {
            var fullBoard = GameBoard.PlayedMoves.Count() == GameBoard.BoardSize * GameBoard.BoardSize;
            return fullBoard;
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

        public abstract void StartGame(string welcomeMessage);

        public abstract PlayerMove GetPlayerMove();

        protected abstract void EndGame();
    }
}