using System;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class ConsoleRenderer: IRenderer
    {
        public void RenderWelcomeMessage()
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n");
        }

        public void RenderMessage(string message)
        {
            throw new NotImplementedException();
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