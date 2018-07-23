namespace TicTacToe.GameRules
{
    public interface IGameRules
    {
        bool HasWinner(Board board);
    }
}