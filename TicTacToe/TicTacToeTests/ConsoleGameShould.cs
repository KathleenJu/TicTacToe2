using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class ConsoleGameShould
    {
        [Fact]
        public void ReturnGameOverWhenThereIsAWinner()
        {
            var game = new ConsoleGame(new TicTacToeRules(), new ConsoleRenderer());
            var player = new Player(1, Symbol.Cross);
            
            game.PlayMove(new PlayerMove(player, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(player, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(player, new Coordinates(2, 0)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
        }
        
        [Fact]
        public void ReturnDrawWhenBoardIsFullAndThereIsNoWinner()
        {
            var game = new ConsoleGame(new TicTacToeRules(), new ConsoleRenderer());
            game.PlayMove(new PlayerMove(new Player(1, Symbol.Cross), new Coordinates(0, 0)));
            game.PlayMove(new PlayerMove(new Player(2, Symbol.Nought), new Coordinates(0, 1)));
            game.PlayMove(new PlayerMove(new Player(1, Symbol.Cross), new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(new Player(2, Symbol.Nought), new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(new Player(2, Symbol.Nought), new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(new Player(1, Symbol.Cross), new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(new Player(2, Symbol.Nought), new Coordinates(2, 0)));
            game.PlayMove(new PlayerMove(new Player(1, Symbol.Cross), new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(new Player(2, Symbol.Nought), new Coordinates(2, 2)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
            Assert.Null(game.GetWinner());
        }
        
        [Fact]
        public void ReturnTheCorrectWinnerOfTheGame()
        {
            var game = new ConsoleGame(new TicTacToeRules(), new ConsoleRenderer());
            var player1 = new Player(1, Symbol.Cross);
            var player2 = new Player(2, Symbol.Nought);
            game.PlayMove(new PlayerMove(player1, new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(player2, new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(player1, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(player2, new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(player1, new Coordinates(2, 2)));
            
            var gameOver = game.IsGameOver();
            var expectedWinner = game.GetWinner();
            var actualWinner = player1;
            
            Assert.True(gameOver);
            Assert.Equal(expectedWinner, actualWinner);
        }
    }
}