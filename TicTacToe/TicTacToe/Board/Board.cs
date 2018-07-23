using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public abstract class Board
    {
        public int BoardSize { get;}
        public List<PlayerMove> PlayedMoves { get; }
        
        protected Board(int boardSize)
        {
            BoardSize = boardSize;
            PlayedMoves = new List<PlayerMove>();
        }
        
        public abstract bool UpdateBoard(PlayerMove playerMove);
    }
}