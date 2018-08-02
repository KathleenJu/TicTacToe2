using System.Collections.Generic;

namespace TicTacToe
{
    public interface IRenderer
    {
        void RenderMessage(string message);
        void RenderGameBoard(Board board);
        void RenderWinner(Player winner);
        int GetBoardSize();
        Player GetPlayerMark(List<Player> gamePlayers);
        PlayerMove GetPlayerMove(Player currentPlayer);
    }
}