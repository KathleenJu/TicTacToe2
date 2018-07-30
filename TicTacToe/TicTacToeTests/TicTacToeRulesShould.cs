using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeRulesShould
    {
        [Theory]
        [InlineData(3, 4)]
        [InlineData(0, 4)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 0)]
        [InlineData(-1, 0)]
        [InlineData(1, 3)]
        public void ReturnTrueIfPositionIsEmptyAndWithinTheBoardsCoordinates(int row, int column)
        {
            var board = new Board();
            var rules = new TicTacToeRules();
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(new Player(1, Symbol.Cross), coordinates);
            var actualOutput = rules.IsValidPlayMove(playerMove, board);

            Assert.False(actualOutput);
        }

        [Theory]
        [InlineData(4, 0)]
        [InlineData(1, -1)]
        [InlineData(2, 4)]
        public void ReturnFalseIfPositionIsNotEmptyAndOutOfTheBoardsCoordinates(int row, int column)
        {
            var board = new Board();
            var rules = new TicTacToeRules();
            var coordinates = new Coordinates(row, column);
            var playerMove = new PlayerMove(new Player(1, Symbol.Cross), coordinates);
            var actualOutput = rules.IsValidPlayMove(playerMove, board);

            Assert.False(actualOutput);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRow()
        {
            var board = new Board();
            var player1 = new Player(1, Symbol.Cross);
            var player2 = new Player(2, Symbol.Nought);
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(2, 0)));
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(2, 2)));
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(2, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumn()
        {
            var board = new Board();
            var player = new Player(1, Symbol.Cross);
            board.UpdateBoard(new PlayerMove(player, new Coordinates(1, 2)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningPrimaryDiagonal()
        {
            var board = new Board();
            var player = new Player(1, Symbol.Cross);
            board.UpdateBoard(new PlayerMove(player, new Coordinates(0, 0)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningSecondaryDiagonal()
        {
            var board = new Board();
            var player = new Player(1, Symbol.Cross);
            board.UpdateBoard(new PlayerMove(player, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningLines()
        {
            var board = new Board();
            var player = new Player(1, Symbol.Cross);
            board.UpdateBoard(new PlayerMove(player, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(player, new Coordinates(2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new Board();
            var player1 = new Player(1, Symbol.Cross);
            var player2 = new Player(2, Symbol.Nought);
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(0, 0)));
            board.UpdateBoard(new PlayerMove(player2, new Coordinates(0, 1)));
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(0, 2)));
            board.UpdateBoard(new PlayerMove(player2, new Coordinates(1, 0)));
            board.UpdateBoard(new PlayerMove(player2, new Coordinates(1, 1)));
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(1, 2)));
            board.UpdateBoard(new PlayerMove(player2, new Coordinates(2, 0)));
            board.UpdateBoard(new PlayerMove(player1, new Coordinates(2, 1)));
            board.UpdateBoard(new PlayerMove(player2, new Coordinates(2, 02)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}