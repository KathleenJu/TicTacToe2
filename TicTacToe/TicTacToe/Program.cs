using System;
using System.Collections.Generic;
using TicTacToe.Enum;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToeBoard(3, 3);
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1, 1)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(2, 2)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(2, 1)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(2, 3)));
            game.PlayPiece(new PlayerMove(Symbol.Cross, new Coordinates(1, 2)));
            var winningMove = new PlayerMove(Symbol.Cross, new Coordinates(1, 3));
            game.PlayPiece(winningMove);
            var hasWinner = game.HasWinner(winningMove);
            foreach (var x in game.WinningLines)
            {
//                    Console.WriteLine("{0}", x);
                foreach (var i in x)
                {
                    Console.WriteLine("{0} {1}", i.GetRow(), i.GetColumn());
                }

            }

            Console.WriteLine("has {0}", hasWinner);
        }
    }
}