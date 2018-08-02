using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.Exception;

namespace TicTacToe
{
    public class Board
    {
        public int BoardSize { get; }
        private readonly List<PlayerMove> _playedMoves;
        public IEnumerable<PlayerMove> PlayedMoves => _playedMoves;

        public Board(int boardSize): this()
        {
            BoardSize = boardSize;
        }

        public Board()
        {
            BoardSize = 3;
            _playedMoves = new List<PlayerMove>();
        }
        
        public void UpdateBoard(PlayerMove playerMove)
        {
            if (IsEmptyPosition(playerMove.Coordinates) && IsValidCoordinate(playerMove.Coordinates))
            {
                _playedMoves.Add(playerMove);
                return;
            }
            throw new InvalidCoordinateException("Invalid move. Either coord is taken or out of the board range. \n");
        }

        private bool IsEmptyPosition(Coordinates coordinates)
        {
            return !_playedMoves.Any(move =>
                move.Coordinates.Row == coordinates.Row && move.Coordinates.Column == coordinates.Column);
        }

        private bool IsValidCoordinate(Coordinates coordinates)
        {
            return coordinates.Row < BoardSize && coordinates.Row >= 0 && coordinates.Column < BoardSize &&
                   coordinates.Column >= 0;
        }

       
    }
}