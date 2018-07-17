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
        public void ResetTheBoardAndClearThePlayedCordinates()
        {
            var game = new TicTacToeBoard(3, 3);
            var actualOutput = game.ResetBoard();
            var expectedOutput = true;

            Assert.Equal(expectedOutput, actualOutput);
            Assert.Empty(game.GetPlayedCoordinates());
        } 
        
        [Fact]
        public void PlayThePlayersTurnIfPositionIsNotTaken()
        {
            var game = new TicTacToeBoard(3, 3);
            var coordinates = new Coordinates(1,1);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayPiece(playerMove);
            var expectedOutput = true;

            Assert.Equal(expectedOutput, actualOutput);
            Assert.True(game.GetPlayedCoordinates().Contains(playerMove));
        } 
        
        [Fact]
        public void NotPlayThePlayersTurnIfPositionIsTaken() //not sure how to test this
        {
            var game = new TicTacToeBoard(3, 3);
            var coordinates = new Coordinates(1,1);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            game.PlayPiece(playerMove);
            var actualOutput = game.PlayPiece(playerMove);
            var expectedOutput = false;

            Assert.Equal(expectedOutput, actualOutput);
        }
        
        [Fact]
        public void ReturnGameStatusPlaying() //not sure how to test this
        {
            var game = new TicTacToeBoard(3, 3);
            var actualOutput = game.GetGameStatus();
            var expectedOutput = GameStatus.PLAYING;

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}