using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardShould
    {
        [Fact]
        public void PutCoordinatesInTheCorrectPositionOnTheBoard()
        {
            var coordinates = new Coordinates(1, 1);
            var list = new List<Coordinates>();
            
            var expectedOutput = list.Contains(coordinates);
            var actualOutput = true;
            
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}