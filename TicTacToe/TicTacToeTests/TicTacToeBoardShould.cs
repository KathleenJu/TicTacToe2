using System;
using System.Collections.Generic;
using TicTacToe;
using Moq;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeBoardShould
    {
        [Fact]
        public void PutCoordinatesInTheCorrectPositionOnTheBoard()
        {
            var game = new TicTacToeBoard(3, 3);
            var actualOutput = game.ResetBoard();
            var expectedOutput = true;

            Assert.Equal(expectedOutput, actualOutput);
            Assert.Empty(game.GetPlayedCoordinates());
        }
    }
}