using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class Board
    {
        public int BoardSize { get; }
        private readonly List<PlayerMove> _playedMoves;
        public IEnumerable<PlayerMove> PlayedMoves => _playedMoves;

        public Board()
        {
            BoardSize = 3;
            _playedMoves = new List<PlayerMove>();
        }
        
        public Board(int boardSize)
        {
            BoardSize = boardSize;
            _playedMoves = new List<PlayerMove>();
        }

        public bool IsEmptyPosition(Coordinates coordinates)
        {
            return !_playedMoves.Any(move => move.Coordinates.Row == coordinates.Row && move.Coordinates.Column == coordinates.Column);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            var boardCoordRange = Enumerable.Range(0, BoardSize);
            return boardCoordRange.Contains(coordinates.Row) && boardCoordRange.Contains(coordinates.Column);
        }

        public void UpdateBoard(PlayerMove playerMove)
        {
            _playedMoves.Add(playerMove);
        }
    }
}