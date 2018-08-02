using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using Moq;
using TicTacToe.Enum;
using TicTacToe.Exception;
using Xunit;

namespace TicTacToeTests
{
    public class BoardShould
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,2)]
        [InlineData(2,0)]
        public void UpdatesBoardWhenThePositionIsEmptyAndWithinTheBoardCoordinates(int row, int column)
        {
            var board = new Board(3);
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(It.IsAny<Player>(), coordinates);
            board.UpdateBoard(playerMove);
            var boardUpdated = board.PlayedMoves.Contains(playerMove);
            
            Assert.True(boardUpdated);
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,2)]
        public void ThrowsAnExceptionWhenPositionIsTaken(int row, int column)
        {
            var board = new Board(3);
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(It.IsAny<Player>(), coordinates);
            board.UpdateBoard(playerMove);
            
            Assert.Throws<InvalidCoordinateException>(() => board.UpdateBoard(playerMove));
        }
        
        
        [Theory]
        [InlineData(-1,0)]
        [InlineData(0,3)]
        [InlineData(2,4)]
        public void ThrowsAnExceptionWhenTheCoordinatesAreOutOfRange(int row, int column)
        {
            var board = new Board(3);
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(It.IsAny<Player>(), coordinates);
            
            Assert.Throws<InvalidCoordinateException>(() => board.UpdateBoard(playerMove));
        }
    }
}