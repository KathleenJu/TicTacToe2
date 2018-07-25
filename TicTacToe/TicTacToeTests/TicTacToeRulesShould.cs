﻿using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeRulesShould
    {
        
        [Theory]
        [InlineData(3,4)]
        [InlineData(0,4)]
        [InlineData(3,1)]
        [InlineData(3,2)]
        [InlineData(3,0)]
        [InlineData(-1,0)]
        [InlineData(1,3)]
        public void ReturnTrueIfPositionIsEmptyAndWithinTheBoardsCoordinates( int row, int column)
        {
            var board = new Board(3);
            var rules = new TicTacToeRules();
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = rules.IsValidPlayMove(playerMove, board);

            Assert.False(actualOutput);
        }
        
        [Theory]
        [InlineData(0,2)]
        [InlineData(1,1)]
        [InlineData(2,2)]
        public void ReturnFalseIfPositionIsNotEmptyAndOutOfTheBoardsCoordinates( int row, int column)
        {
            var board = new Board(3);
            var rules = new TicTacToeRules();
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(Symbol.Cross, coordinates);
            var actualOutput = rules.IsValidPlayMove(playerMove, board);

            Assert.True(actualOutput);
        }
        
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRow()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumn()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningPrimaryDiagonal()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningSecondaryDiagonal()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningLines()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new Board(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(0, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(2, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(2, 02)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}