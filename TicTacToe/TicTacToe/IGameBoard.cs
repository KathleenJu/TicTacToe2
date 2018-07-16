using System.Collections.Generic;
using TicTacToe.Enum;

namespace TicTacToe
{
    public interface IGameBoard
    {
        bool PlayPiece(Coordinates coordinates);
        GameStatus GetGameStatus();
        void StartGame();
        bool ResetBoard();
    }
}