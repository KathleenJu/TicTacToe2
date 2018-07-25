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
            var arrayBoard = new List<List<Symbol>>
            {
                new List<Symbol>{Symbol.Empty, Symbol.Empty, Symbol.Empty},
                new List<Symbol>{Symbol.Empty, Symbol.Empty, Symbol.Empty},
                new List<Symbol>{Symbol.Empty, Symbol.Empty, Symbol.Empty}
            };
            
            foreach (var playedMove in board.PlayedMoves)
            {
                arrayBoard[playedMove.Coordinates.Row][playedMove.Coordinates.Column] = playedMove.Symbol;   
            }

            for (var row = 0; row < board.BoardSize; row++)
            {
                for (var col = 0; col < board.BoardSize; col++)
                {
                    if (arrayBoard[row][col] != Symbol.Cross || arrayBoard[row][col] != Symbol.Nought)
                    {
                        arrayBoard[row][col] = Symbol.Empty;
                    }
                    Console.Write(" " + (char)arrayBoard[row][col] + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public void RenderWinner()
        {
            throw new NotImplementedException();
        }
    }
}