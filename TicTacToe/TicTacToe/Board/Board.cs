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

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            _playedMoves = new List<PlayerMove>();
        }

        public bool IsEmptyPosition(Coordinates coordinates)
        {
            return !_playedMoves.Any(move => move.Coordinates == coordinates);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return Enumerable.Range(0, BoardSize).Contains(coordinates.Row) &&
                   Enumerable.Range(0, BoardSize).Contains(coordinates.Column);
        }

        public void UpdateBoard(PlayerMove playerMove)
        {
            _playedMoves.Add(playerMove);
        }
    }
}