using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public abstract class Board
    {
        protected int BoardHeight;
        protected int BoardWidth;
        protected readonly List<PlayerMove> PlayedMoves;
        protected GameStatus GameStatus;

        protected Board(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
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
            return !PlayedMoves.Any(move => move.GetCoordinates() == playerMove.GetCoordinates());
        }

        public GameStatus GetGameStatus()
        {
            return GameStatus;
        }

        public List<PlayerMove> GetPlayerMoves()
        {
            return PlayedMoves;
        }

        public Symbol? GetWinner() // make it nullable?
        {
            if (HasWinner())
            {
                var lastPlayedSymbol = PlayedMoves.Last().GetSymbol();
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

            var draw = IsDrawGame();
            return draw;
        }

        private bool IsDrawGame()
        {
            GameStatus = GameStatus.OVER;
            throw new NotImplementedException();
        }

        public abstract bool HasWinner();
    }
}