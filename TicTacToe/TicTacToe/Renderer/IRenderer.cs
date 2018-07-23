namespace TicTacToe
{
    public interface IRenderer
    {
        void RenderMessage(string message);
        void RenderGameBoard(Board board);
        void RenderWinner(); 
    }
}