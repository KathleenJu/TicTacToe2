﻿using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeRulesShould
    {
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRow()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumn()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningPrimaryDiagonal()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningSecondaryDiagonal()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningLines()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var gameOver = rules.HasWinner(board);

            Assert.False(gameOver);
        }

        [Fact]
        public void ReturnGameOverWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new TicTacToeBoard(3);
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            board.PlayMove(new PlayerMove(Symbol.Naught, new Coordinates(0, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.PlayMove(new PlayerMove(Symbol.Naught, new Coordinates(1, 0)));
            board.PlayMove(new PlayerMove(Symbol.Naught, new Coordinates(1, 1)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            board.PlayMove(new PlayerMove(Symbol.Naught, new Coordinates(2, 0)));
            board.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            board.PlayMove(new PlayerMove(Symbol.Naught, new Coordinates(2, 02)));
            var rules = new TicTacToeRules();
            var gameOver = rules.HasWinner(board);

            Assert.True(gameOver);
        }
    }
}