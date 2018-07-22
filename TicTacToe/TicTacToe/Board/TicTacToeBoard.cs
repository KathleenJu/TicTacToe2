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
    }
}