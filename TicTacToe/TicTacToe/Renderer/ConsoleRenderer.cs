using System;
using System.Collections.Generic;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class ConsoleRenderer : IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.Write("{0}", message);
        }

        public void RenderGameBoard(Board board)
        {
            var arrayBoard = new List<List<Symbol>>();
            foreach (var playedMove in board.PlayedMoves)
            {
                arrayBoard[playedMove.Coordinates.Row - 1][playedMove.Coordinates.Column - 1] = playedMove.Symbol;
            }

            for (var row = 0; row < board.BoardSize; row++)
            {
                for (var col = 0; col < board.BoardSize; col++)
                {
//                    arrayBoard[row][] = ;
                }
            }
        }

        public void RenderWinner()
        {
            throw new NotImplementedException();
        }
    }
}