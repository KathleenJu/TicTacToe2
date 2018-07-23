using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public TicTacToeBoard(int boardSize) : base(boardSize)
        {
        }

        public override bool UpdateBoard(PlayerMove playerMove) //UpdatePlayedMoves?
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