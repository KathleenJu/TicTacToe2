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
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var game = new TicTacToeGame(board, new TicTacToeRules());
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
        }
        
        [Fact]
        public void ReturnDrawWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new TicTacToeBoard(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(0, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(2, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(2, 02)));
            var game = new TicTacToeGame(board, new TicTacToeRules());
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
            Assert.Null(game.GetWinner());
        }
        
        [Fact]
        public void ReturnTheCorrectWinnerOfTheGame()
        {
            var board = new TicTacToeBoard(3);
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(Symbol.Nought, new Coordinates(2, 1)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(Symbol.Cross, new Coordinates(2, 0)));
            var game = new TicTacToeGame(board, new TicTacToeRules());
            var gameOver = game.IsGameOver();
            var expectedWinner = game.GetWinner();
            var actualWinner = Symbol.Cross;
            
            Assert.True(gameOver);
            Assert.Equal(expectedWinner, actualWinner);
        }
    }
}