using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class GameStatusCheckerShould
    {
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningLine()
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1,1)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1,2)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1,3)));
            var playedCoordinates = game.GetPlayedCoordinates();
            var gameChecker = new GameStatusChecker(playedCoordinates);
            var actualOutput = gameChecker.HasWinner();
            var expectedOutput = true;
            
            Assert.Equal(actualOutput, expectedOutput);

        }
    }
}