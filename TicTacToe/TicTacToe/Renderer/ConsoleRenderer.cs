using System;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class ConsoleRenderer: IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void RenderGameBoard(Board board)
        {
            throw new NotImplementedException();
        }

        public void RenderWinner()
        {
            throw new NotImplementedException();
        }
    }
}