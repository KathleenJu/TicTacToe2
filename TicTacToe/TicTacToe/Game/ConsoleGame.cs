using System;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class ConsoleGame : Game
    {
        private readonly ConsoleRenderer ConsoleRenderer;
        
        public ConsoleGame(Board gameBoard, IGameRules gameRules, ConsoleRenderer consoleRenderer) : base(gameBoard, gameRules)
        {
            ConsoleRenderer = consoleRenderer;
        }

        public override void StartGame(string welcomeMessage)
        {
            ConsoleRenderer.RenderMessage(welcomeMessage);
            ConsoleRenderer.RenderGameBoard(GameBoard);
           
            GamePlayers.Add(new Player(1, Symbol.Cross));
            GamePlayers.Add(new Player(2, Symbol.Nought));
            CurrentPlayer = GamePlayers.OrderBy(player => player.Id).First();
            
            while (GameStatus != GameStatus.OVER)
            {
                var move = GetPlayerMove();
                PlayMove(move);
                if (IsGameOver())
                {
                    GetWinner();
                }
            }
        }

        public override PlayerMove GetPlayerMove()
        {
            ConsoleRenderer.RenderMessage("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ");
            var quitGame = "q";
            var playerInput = Console.ReadLine();
            throw new NotImplementedException();

        }
        
        private static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9]$");
        }
    }
}