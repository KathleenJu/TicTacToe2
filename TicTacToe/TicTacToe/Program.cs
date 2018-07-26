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
            var board = new Board(3);
            var rules = new TicTacToeRules();
            var renderer = new ConsoleRenderer();
            var game = new ConsoleGame(board, rules, renderer);
            
            game.StartGame("Welcome to Tic Tac Toe! \n");
        } 
    }
}