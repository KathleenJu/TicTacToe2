using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeBoard : IBoard
    {
        public int BoardSize { get; }
        public List<PlayerMove> PlayedMoves { get; }
        
        public TicTacToeBoard(int boardSize)
        {
            BoardSize = boardSize;
            PlayedMoves = new List<PlayerMove>();
        }

        public bool PlayMove(PlayerMove playerMove)
        {
            if (IsEmptyPosition(playerMove.Coordinates) && IsValidCoordinate(playerMove.Coordinates))
            {
                PlayedMoves.Add(playerMove);
                return true;
            }
            return false;
        }

        private bool IsEmptyPosition(Coordinates coordinates)
        {
            return !PlayedMoves.Any(move => move.Coordinates == coordinates);
        }

        private bool IsValidCoordinate(Coordinates coordinates)
        {
            return Enumerable.Range(0, BoardSize).Contains(coordinates.Row) &&
                   Enumerable.Range(0, BoardSize).Contains(coordinates.Column);
        }
    }
}