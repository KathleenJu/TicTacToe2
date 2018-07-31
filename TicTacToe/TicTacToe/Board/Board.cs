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
        public int BoardSize { get; private set; }
        private readonly List<PlayerMove> _playedMoves;
        public IEnumerable<PlayerMove> PlayedMoves => _playedMoves;

        public Board()
        {
            BoardSize = 3;
            _playedMoves = new List<PlayerMove>();
        }

        public bool IsEmptyPosition(Coordinates coordinates)
        {
            return !_playedMoves.Any(move =>
                move.Coordinates.Row == coordinates.Row && move.Coordinates.Column == coordinates.Column);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return coordinates.Row < BoardSize && coordinates.Row >= 0 && coordinates.Column < BoardSize &&
                   coordinates.Column >= 0;
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

        public void UpdateBoardSize(int boardSize) // constructor should receive boardsize
        {
            BoardSize = boardSize;
        }
    }
}