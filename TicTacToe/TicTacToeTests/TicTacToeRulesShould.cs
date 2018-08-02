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
            var board = new Board(3);
            var player1 = new Player(1, 'X');
            var player2 = new Player(2, 'O');
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
            var board = new Board(3);
            var player = new Player(1, 'X');
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
            var board = new Board(3);
            var player = new Player(1, 'X');
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
            var board = new Board(3);
            var player = new Player(1, 'X');
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
            var board = new Board(3);
            var player = new Player(1, 'X');
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
            var board = new Board(3);
            var player1 = new Player(1, 'X');
            var player2 = new Player(2, 'O');
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