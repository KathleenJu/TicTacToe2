using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class Board 
    {
        protected readonly List<PlayerMove> PlayedCoordinates;
        protected int BoardHeight;
        protected int BoardWidth;
        protected readonly GameStatus GameStatus;

        public Board(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            PlayedCoordinates = new List<PlayerMove>();
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayPiece(PlayerMove playerMove)
        {
            if (IsEmptyPosition(playerMove))
            {
                PlayedCoordinates.Add(playerMove);
                return true;
            }
            return false;
        }

        private bool IsEmptyPosition(PlayerMove playerMove)
        {
            return !PlayedCoordinates.Any(x => x.GetCoordinates() == playerMove.GetCoordinates());
        }

        public GameStatus GetGameStatus()
        {
            return GameStatus;
        }

        public List<PlayerMove> GetPlayedCoordinates()
        {
            return PlayedCoordinates;
        }
    }
}