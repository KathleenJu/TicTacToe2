using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public abstract class Board 
    {
        protected readonly List<PlayerMove> PlayerMoves;
        public int BoardHeight;
        protected int BoardWidth;
        protected readonly GameStatus GameStatus;

        protected Board(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            PlayerMoves = new List<PlayerMove>();
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayMove(PlayerMove playerMove)
        {
            if (IsEmptyPosition(playerMove))
            {
                PlayerMoves.Add(playerMove);
                return true;
            }
            return false;
        }

        private bool IsEmptyPosition(PlayerMove playerMove)
        {
            return !PlayerMoves.Any(x => x.GetCoordinates() == playerMove.GetCoordinates());
        }

        public GameStatus GetGameStatus()
        {
            return GameStatus;
        }

        public List<PlayerMove> GetPlayerMoves()
        {
            return PlayerMoves;
        }

        public abstract bool IsWinningMove(PlayerMove playerMove);
    }
}