using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using Moq;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class BoardShould
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,2)]
        [InlineData(2,0)]
        public void ReturnTrueWhenThePositionIsEmpty(int row, int column)
        {
            var board = new Board();
            var coordinates = new Coordinates(row, column);
            var actualOutput = board.IsEmptyPosition(coordinates);

            Assert.True(actualOutput);
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,2)]
        public void ReturnFalseIfPositionIsTaken(int row, int column)
        {
            var board = new Board();
            var coordinates = new Coordinates(row, column);
            board.UpdateBoard(new PlayerMove(new Player(1, Symbol.Nought), coordinates));
            var actualOutput = board.IsEmptyPosition(coordinates);
 
            Assert.False(actualOutput);
        }
        
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,2)]
        public void UpdateTheBoardWithThePlayMove(int row, int column)
        {
            var board = new Board();
            var coordinates = new Coordinates(row, column);
            var playMove = new PlayerMove(new Player(1, Symbol.Nought), coordinates);
            board.UpdateBoard(playMove);
            
            Assert.True(board.PlayedMoves.Contains(playMove));
        }
        
        [Theory]
        [InlineData(-1,0)]
        [InlineData(0,3)]
        [InlineData(2,4)]
        public void ReturnTrueIfTheCoordinatesAreOutOfRange(int row, int column)
        {
            var board = new Board();
            var coordinates = new Coordinates(row, column);
            var actualOutput = board.IsValidCoordinate(coordinates);

            Assert.False(actualOutput);
        }
        
        [Theory]
        [InlineData(-1,0)]
        [InlineData(0,3)]
        [InlineData(2,4)]
        public void ReturnFalseIfTheCoordinatesAreOutOfRange(int row, int column)
        {
            var board = new Board();
            var coordinates = new Coordinates(row, column);
            var actualOutput = board.IsValidCoordinate(coordinates);

            Assert.False(actualOutput);
        }
    }
}