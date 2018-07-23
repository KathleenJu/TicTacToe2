using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeGameShould
    {
        [Fact]
        public void ReturnGameOverWhenThereIsAWinner()
        {
            var board = new TicTacToeBoard(3);
            var game = new TicTacToeConsoleGame(board, new TicTacToeRules());
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
        }
        
        [Fact]
        public void ReturnDrawWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new TicTacToeBoard(3);
            var game = new TicTacToeConsoleGame(board, new TicTacToeRules());
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(0, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(2, 0)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(2, 02)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
            Assert.Null(game.GetWinner());
        }
        
        [Fact]
        public void ReturnTheCorrectWinnerOfTheGame()
        {
            var board = new TicTacToeBoard(3);
            var game = new TicTacToeConsoleGame(board, new TicTacToeRules());
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(Symbol.Nought, new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var gameOver = game.IsGameOver();
            var expectedWinner = game.GetWinner();
            var actualWinner = Symbol.Cross;
            
            Assert.True(gameOver);
            Assert.Equal(expectedWinner, actualWinner);
        }
    }
}