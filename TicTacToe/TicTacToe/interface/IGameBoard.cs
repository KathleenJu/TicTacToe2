using System.Collections.Generic;
using TicTacToe.Enum;

namespace TicTacToe
{
    public interface IGameBoard
    {
        bool PlayPiece(PlayedCoordinates playedCoordinates);
        GameStatus GetGameStatus();
        void StartGame();
        bool ResetBoard();
    }
}