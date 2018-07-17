using System.Collections.Generic;
using TicTacToe.Enum;

namespace TicTacToe
{
    public interface IGameBoard
    {
        bool PlayPiece(PlayerMove playerMove);
        GameStatus GetGameStatus();
        void StartGame();
        bool ResetBoard();
    }
}