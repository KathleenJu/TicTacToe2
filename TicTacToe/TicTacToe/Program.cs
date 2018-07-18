using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToeBoard(3, 3);
//            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1, 3)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1, 3)));
            var winningMove = new PlayerMove(Symbol.Cross, new Coordinates(1, 1));
            game.PlayPiece(winningMove);
            var hasWinner = game.HasWinner(winningMove);

            Console.WriteLine("has {0}", hasWinner);
        } 
    }
}