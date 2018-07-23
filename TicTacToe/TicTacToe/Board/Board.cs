using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class Board
    {
        public int BoardSize { get;}
        public List<PlayerMove> PlayedMoves { get; }
        
        protected Board(int boardSize)
        {
            BoardSize = boardSize;
            PlayedMoves = new List<PlayerMove>();
        }

        public bool IsEmptyPosition(Coordinates coordinates)
        {
            return !PlayedMoves.Any(move => move.Coordinates == coordinates);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return Enumerable.Range(0, BoardSize).Contains(coordinates.Row) &&
                   Enumerable.Range(0, BoardSize).Contains(coordinates.Column);
        }

        public void UpdateBoard(PlayerMove playerMove)
        {
            PlayedMoves.Add(playerMove);
        }
    }
}