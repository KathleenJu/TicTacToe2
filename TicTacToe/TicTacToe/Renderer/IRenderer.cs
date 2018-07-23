namespace TicTacToe
{
    public interface IRenderer
    {
        void RenderWelcomeMessage();
        void RenderMessage(string message);
        void RenderGameBoard(Board board);
        void RenderWinner(); 
    }
}