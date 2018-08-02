using System;
using System.Collections.Generic;
using System.Net;
using TicTacToe.GameRules;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new TicTacToeRules());
            var consoleRenderer = new ConsoleRenderer();
            var x = new X(game, consoleRenderer);
            x.Play();     
        }
    }
    
    //move to a diff file
}