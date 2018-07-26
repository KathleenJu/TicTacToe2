using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class ConsoleRenderer : IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.Write(message);
        }

        public void RenderGameBoard(Board board)
        {
            for (var row = 0; row < board.BoardSize; row++)
            {
                for (var col = 0; col < board.BoardSize; col++)
                {
                    var symbolOfCurrentPosition = board.PlayedMoves
                        .Where(move => move.Coordinates.Row == row && move.Coordinates.Column == col)
                        .Select(move => move.Player.Symbol);
                    if (symbolOfCurrentPosition.Any())
                    {
                        Console.Write(" " + (char) symbolOfCurrentPosition.First() + " ");
                    }
                    else
                    {
                        Console.Write(" " + (char) Symbol.Empty + " ");
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public void RenderWinner(Player winner)
        {
            if (winner != null)
            {
                Console.WriteLine("Move accepted, well done Player " + winner.Id + " you've won the game!");
            }
            else
            {
                Console.WriteLine("Game was a draw!"); //if called earlier in the game, wont say no winner 
            }
        }
    }
}