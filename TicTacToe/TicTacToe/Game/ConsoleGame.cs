using System;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class ConsoleGame : Game
    {
        private readonly ConsoleRenderer ConsoleRenderer;

        public ConsoleGame(Board gameBoard, IGameRules gameRules, ConsoleRenderer consoleRenderer) : base(gameBoard,
            gameRules)
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
                PlayMove(GetPlayerMove());
                ConsoleRenderer.RenderGameBoard(GameBoard);
                if (IsGameOver())
                {
                    GetWinner();
                }
                CurrentPlayer = GamePlayers.Where(player => player != CurrentPlayer).Select(player => player).First();
            }
        }

        public override PlayerMove GetPlayerMove()
        {
            var playerPromptMessage = "Player " + CurrentPlayer.Id + " enter a coord x,y to place your" + CurrentPlayer.Symbol + " or enter 'q' to give up: ";
            ConsoleRenderer.RenderMessage(playerPromptMessage);
            var quitGame = "q";
            var playerInput = Console.ReadLine();
            if (playerInput == quitGame)
            {
                EndGame();
            }
            if (InputAValidCoord(playerInput))
            {
                {
                    var row = int.Parse(playerInput.Split(',')[0]) - 1;
                    var column = int.Parse(playerInput.Split(',')[1]) - 1;
                    var playerCoordinates = new Coordinates(row, column);
                    return new PlayerMove(Symbol.Cross, playerCoordinates);
                }
            }
            throw new InvalidCoordinateFormatException();
        }

        private static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9]$");
        }

        protected override void EndGame()
        {
            GameStatus = GameStatus.OVER;
        }
    }
}