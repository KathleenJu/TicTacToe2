using TicTacToe.Enum;

namespace TicTacToe
{
    interface IGame
    {
        bool IsGameOver();
        Symbol? GetWinner();
    } 
}