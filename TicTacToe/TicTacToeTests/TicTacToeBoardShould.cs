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
        [Fact]
        public void PlayThePlayersMoveIfPositionIsNotTaken()
        {
            var game = new TicTacToeBoard(3);
            var coordinates = new Coordinates(0, 0);
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

        [Fact]
        public void ReturnGameStatusPlaying() 
        {
            var game = new TicTacToeBoard(3);
            var actualOutput = game.GameStatus;
            var expectedOutput = GameStatus.PLAYING;

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}