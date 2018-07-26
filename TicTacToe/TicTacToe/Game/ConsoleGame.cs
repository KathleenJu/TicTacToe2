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
                PlayCurrentPlayersTurn();
            }

            ConsoleRenderer.RenderWinner(GetWinner());
        }

        private void PlayCurrentPlayersTurn()
        {
            try
            {
                PlayMove(GetPlayerMove());
            }
            catch (InvalidCoordinateException ex)
            {
                ConsoleRenderer.RenderMessage(ex.ExceptionMessage);
                return;
            }

            ConsoleRenderer.RenderMessage("Move accepted, here's the current board: \n");
            ConsoleRenderer.RenderGameBoard(GameBoard);
            if (IsGameOver())
            {
                EndGame();
            }

            CurrentPlayer = GamePlayers.Where(player => player != CurrentPlayer).Select(player => player).First();
        }

        protected override void AddPlayersToGame()
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

            if (IsInputAValidCoord(playerInput))
            {
                var row = int.Parse(playerInput.Split(',')[0]) - 1;
                var column = int.Parse(playerInput.Split(',')[1]) - 1;
                var playerCoordinates = new Coordinates(row, column);
                return new PlayerMove(CurrentPlayer, playerCoordinates);
            }

            throw new InvalidCoordinateException("Wrong coordination format. Try again. \n");
        }

        private static bool IsInputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9]$");
        }
    }
}