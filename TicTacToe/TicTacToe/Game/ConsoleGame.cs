using System;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class ConsoleGame : Game
    {
        private readonly IRenderer ConsoleRenderer;

        public ConsoleGame(IGameRules gameRules, IRenderer consoleRenderer) : base(gameRules)
        {
            ConsoleRenderer = consoleRenderer;
        }

        public override void StartGame(string welcomeMessage)
        {
            ConsoleRenderer.RenderMessage(welcomeMessage);
            ConsoleRenderer.RenderGameBoard(GameBoard);

            SetGameBoard(GetBoardSize());
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

        protected override int GetBoardSize()
        {
            int boardSize;
            ConsoleRenderer.RenderMessage(
                "Default board size is 3x3. \nIf you would like to change the board size, type in the number size or presss Enter to proceed with 3x3 board: ");
            var boardSizeInput = Console.ReadLine();
            if (boardSizeInput == "")
            {
                return 3;
            }

            while (!int.TryParse(boardSizeInput, out boardSize))
            {
                ConsoleRenderer.RenderMessage(
                    "Please type in a number for the board size: ");
                boardSizeInput = Console.ReadLine();
            }

            while (boardSize < 3 || boardSize > 10)
            {
                try
                {
                    ConsoleRenderer.RenderMessage(
                        "Minimum board size is 3 and can only be up to 10. Please enter the board size: ");
                    boardSize = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {//ignored
                }
            }

            return boardSize;
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


        protected override PlayerMove GetPlayerMove()
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