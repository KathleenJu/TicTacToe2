using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : Board
    {
        public TicTacToeBoard(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {
        }

//        public abstract bool HasWinner(); //will playermove but how to determine if no winner? , playermove class can have field IsWinningMove?
        //board have currentPlayerSymbol field so when haswinner is true, then getcurrentplayersymbol can be called to get the winner's symbol
    }
}