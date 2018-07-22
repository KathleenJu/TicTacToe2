using System;
using System.Collections.Generic;
using TicTacToe;
using Moq;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeBoardShould
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,2)]
        [InlineData(1,0)]
        [InlineData(1,1)]
        [InlineData(1,2)]
        [InlineData(2,0)]
        [InlineData(2,1)]
        [InlineData(2,2)]
        public void PlayTheMoveIfPositionIsNotTakenAndMoveIsAValidPosition(int row, int column)
        {
            var game = new TicTacToeBoard(3);
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayMove(playerMove);

            Assert.True(actualOutput);
            Assert.True(game.PlayedMoves.Contains(playerMove));
        }

        [Fact]
        public void NotPlayThePlayersMoveIfPositionIsTaken()
        {
            var game = new TicTacToeBoard(3);
            var coordinates = new Coordinates(0, 0);
            game.PlayMove(new PlayerMove(Symbol.Naught, coordinates));
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayMove(playerMove);

            Assert.False(actualOutput);
        }

        [Theory]
        [InlineData(3,4)]
        [InlineData(0,4)]
        [InlineData(3,1)]
        [InlineData(3,2)]
        [InlineData(3,0)]
        [InlineData(-1,0)]
        [InlineData(1,3)]
        public void NotPlayTheMoveIfPositionIsNotValidOrOutOfTheBoardsCoordinates( int row, int column)
        {
            var game = new TicTacToeBoard(3);
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayMove(playerMove);

            Assert.False(actualOutput);
        }
    }
}