using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    interface IBoard
    {
        bool PlayMove(PlayerMove playerMove);
    }
}