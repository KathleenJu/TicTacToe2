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
            var game = new TicTacToeBoard(3, 3);
            var coordinates = new Coordinates(0, 0);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayMove(playerMove);

            Assert.True(actualOutput);
            Assert.True(game.GetPlayerMoves().Contains(playerMove));
        }

        [Fact]
        public void NotPlayThePlayersMoveIfPositionIsTaken() //not sure how to test this
        {
            var game = new TicTacToeBoard(3, 3);
            var coordinates = new Coordinates(0, 0);
            game.PlayMove(new PlayerMove(Symbol.Naught, coordinates));
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = game.PlayMove(playerMove);

            Assert.False(actualOutput);
        }

        [Fact]
        public void ReturnGameStatusPlaying() //not sure how to test this
        {
            var game = new TicTacToeBoard(3, 3);
            var actualOutput = game.GetGameStatus();
            var expectedOutput = GameStatus.PLAYING;

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRow()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            var hasWinner = game.IsGameOver();

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumn()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var hasWinner = game.IsGameOver();

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningPrimaryDiagonal()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var hasWinner = game.IsGameOver();

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningSecondaryDiagonal()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var hasWinner = game.IsGameOver();

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningLines()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var hasWinner = game.IsGameOver();

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnDrawWhenGameIsOverAndNoWinner()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var gameOver = game.IsGameOver();

            Assert.False(gameOver);
        }
    }
}