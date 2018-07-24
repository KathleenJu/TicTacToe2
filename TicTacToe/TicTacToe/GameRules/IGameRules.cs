namespace TicTacToe.GameRules
{
    public interface IGameRules
    {
        bool HasWinner(Board board);
        bool IsValidPlayMove(PlayerMove playerMove, Board board);
    }
}