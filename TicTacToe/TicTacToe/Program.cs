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
            var rules = new TicTacToeRules();
            var renderer = new ConsoleRenderer();
            var game = new ConsoleGame(rules, renderer);
            
            game.StartGame("Welcome to Tic Tac Toe! \n");
        } 
    }
}