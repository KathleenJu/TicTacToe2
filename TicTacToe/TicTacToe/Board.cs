using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public abstract class Board
    {
        public int BoardSize { get; }
        public List<PlayerMove> PlayedMoves { get; }
        public GameStatus GameStatus { get; private set; }
        
        protected Board(int boardSize)
        {
            BoardSize = boardSize;
            PlayedMoves = new List<PlayerMove>();
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayMove(PlayerMove playerMove)
        {
            if (IsEmptyPosition(playerMove))
            {
                PlayedMoves.Add(playerMove);
                return true;
            }

            return false;
        }

        private bool IsEmptyPosition(PlayerMove playerMove)
        {
            return !PlayedMoves.Any(move => move.Coordinates == playerMove.Coordinates);
        }

        public Symbol? GetWinner()
        {
            if (HasWinner())
            {
                var lastPlayedSymbol = PlayedMoves.Last().Symbol;
                return lastPlayedSymbol;
            }
            return null;
        }

        public bool IsGameOver()
        {
            if (GetWinner() != null)
            {
                GameStatus = GameStatus.OVER;
                return true;
            }
            var isDrawGame = IsDrawGame();
            return isDrawGame;
        }

        private bool IsDrawGame()
        {
            var fullBoard = PlayedMoves.Count == BoardSize * BoardSize;
            if (fullBoard)
            {
                GameStatus = GameStatus.OVER;
                return true;
            }
            return false;
        }

        public abstract bool HasWinner();
    }
}