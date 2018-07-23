namespace TicTacToe.GameRules
{
    public interface IGameRules
    {
        bool HasWinner(Board board);
        bool CheckPlayMovePosition(PlayerMove playerMove, Board board);
    }
}