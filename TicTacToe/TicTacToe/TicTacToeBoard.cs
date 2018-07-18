using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public readonly List<List<Coordinates>> WinningLines = new List<List<Coordinates>>();

        public TicTacToeBoard(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {
        }

        public bool HasWinner(PlayerMove playerMove)
        {
            var coordinates = PlayedCoordinates.Where(move => move.Symbol == playerMove.Symbol)
                .Select(move => move.GetCoordinates()).ToList();
            var hasWinningLine = new List<bool>();
            for (int row = 1; row < BoardHeight + 1; row++)
            {
                hasWinningLine.Add(coordinates.Where(coord => coord.GetRow() == row)
                                                 .Distinct()
                                                 .Count() == BoardHeight);
                hasWinningLine.Add(coordinates.Where(coord => coord.GetColumn() == row)
                                                 .Distinct()
                                                 .Count() == BoardHeight);
            }

            hasWinningLine.Add(coordinates.Select(coord => coord)
                                       .Where((coord, row) => (coord.GetRow() == row + 1 && coord.GetColumn() == BoardHeight) || (coord.GetRow() == 2 && coord.GetColumn() == 2) ||
                                                              coord.GetRow() == 3 && coord.GetColumn() == 1).Count() == BoardHeight);
            
            return hasWinningLine.Any(x => x);
        }

        public bool CheckWinningRow(List<bool> hasWinningLine, List<Coordinates> coordinates)
        {
            for (int row = 1; row < BoardHeight + 1; row++)
            {
                hasWinningLine.Add(coordinates.Where(coord => coord.GetRow() == row)
                                       .Distinct()
                                       .Count() == BoardHeight);
                hasWinningLine.Add(coordinates.Where(coord => coord.GetColumn() == row)
                                       .Distinct()
                                       .Count() == BoardHeight);
            } 
        }
    }
}