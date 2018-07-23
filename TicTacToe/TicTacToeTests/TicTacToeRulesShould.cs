using TicTacToe;
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
            var board = new TicTacToeBoard(3);
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
            var board = new TicTacToeBoard(3);
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
            var board = new TicTacToeBoard(3);
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
            var board = new TicTacToeBoard(3);
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
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}