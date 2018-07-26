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
            ConsoleRenderer.RenderMessage("Here's the current board: \n");
            ConsoleRenderer.RenderGameBoard(GameBoard);
            AddPlayersToGame();
            SetCurrentPlayer();

            while (GameStatus != GameStatus.OVER)
            {
                PlayMove(GetPlayerMove());
                ConsoleRenderer.RenderMessage("Move accepted, here's the current board: \n");
                ConsoleRenderer.RenderGameBoard(GameBoard);
                IsGameOver();
                CurrentPlayer = GamePlayers.Where(player => player != CurrentPlayer).Select(player => player).First();
            }
//            ConsoleRenderer.RenderWinner(GetWinner());
        }

        private void AddPlayersToGame()
        {
            GamePlayers.Add(new Player(1, Symbol.Cross));
            GamePlayers.Add(new Player(2, Symbol.Nought));
        }

        protected override void SetCurrentPlayer()
        {
            CurrentPlayer = GamePlayers.OrderBy(player => player.Id).First();
        }

        public override PlayerMove GetPlayerMove()
        {
            var playerPromptMessage = "Player " + CurrentPlayer.Id + " enter a coord x,y to place your " +
                                      (char) CurrentPlayer.Symbol + " or enter 'q' to give up: ";
            ConsoleRenderer.RenderMessage(playerPromptMessage);
            const string quitGame = "q";
            var playerInput = Console.ReadLine();
            if (playerInput == quitGame)
            {
                EndGame();
            }

            if (InputAValidCoord(playerInput))
            {
                var row = int.Parse(playerInput.Split(',')[0]) - 1;
                var column = int.Parse(playerInput.Split(',')[1]) - 1;
                var playerCoordinates = new Coordinates(row, column);
                return new PlayerMove(CurrentPlayer, playerCoordinates);
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