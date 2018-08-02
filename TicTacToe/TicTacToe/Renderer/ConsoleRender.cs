using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using TicTacToe.Enum;
using TicTacToe.Exception;

namespace TicTacToe
{
    public class ConsoleRenderer : IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.Write(message);
        }

        public int GetBoardSize()
        {
            int boardSize;
            Console.Write("Default board size is 3x3. \nWant to change the board size? Type in the number size or presss Enter to proceed with 3x3 board: ");
            var boardSizeInput = Console.ReadLine();
            if (boardSizeInput == "")
            {
                return 3;
            }

            while (!int.TryParse(boardSizeInput, out boardSize))
            {
                Console.Write("Please type in a number for the board size: ");
                boardSizeInput = Console.ReadLine();
            }

            while (boardSize < 3 || boardSize > 10)
            {
                try
                {
                    Console.Write("Minimum board size is 3 and can only be up to 10. Please enter the board size: ");
                    boardSize = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    //ignored
                }
            }

            return boardSize;
        }

        public Player GetPlayerMark(List<Player> gamePlayers)
        {
            var playerId = gamePlayers == null ? 1 : gamePlayers.Count + 1;
            Console.Write("Player {0} pick your mark e.g. X or O: ", playerId);
            var playerInput = Console.ReadLine();
            char mark;
            while(!char.TryParse(playerInput, out mark))
            {
                Console.Write("Please type in a character for your mark on the board: ");
                playerInput = Console.ReadLine();
            }   
            
           return new Player(playerId, char.ToUpper(mark));
        }
        
        public void RenderGameBoard(Board board)
        {
            for (var row = 0; row < board.BoardSize; row++)
            {
                for (var col = 0; col < board.BoardSize; col++)
                {
                    var symbolOfCurrentPosition = board.PlayedMoves
                        .Where(move => move.Coordinates.Row == row && move.Coordinates.Column == col)
                        .Select(move => move.Player.Mark);
                    if (symbolOfCurrentPosition.Any())
                    {
                        Console.Write(" " + (char) symbolOfCurrentPosition.First() + " ");
                    }
                    else
                    {
                        Console.Write(" " + (char) Symbol.Empty + " ");
                    }
                    
                }

                Console.WriteLine(Environment.NewLine);
            }
        }

        public PlayerMove GetPlayerMove(Player currentPlayer)
        {
            var playerPromptMessage = "Player " + currentPlayer.Id + " enter a coord x,y to place your " + (char) currentPlayer.Mark + " or enter 'q' to give up: ";
            Console.Write(playerPromptMessage);
            const string quitGame = "q";
            var playerInput = Console.ReadLine();
            if (playerInput == quitGame)
            {
                throw new QuitGameException("Player " +  currentPlayer.Id + " quit the game. End of game.");
            }

            if (IsInputAValidCoord(playerInput))
            {
                var row = int.Parse(playerInput.Split(',')[0]) - 1;
                var column = int.Parse(playerInput.Split(',')[1]) - 1;
                var playerCoordinates = new Coordinates(row, column);
                return new PlayerMove(currentPlayer, playerCoordinates);
            }

            throw new InvalidCoordinateException("Wrong coordination format. Try again. \n");
        }

        private static bool IsInputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9]$");
        }

        public void RenderWinner(Player winner)
        {
            if (winner != null)
            {
                Console.WriteLine("Move accepted, well done Player " + winner.Id + " you've won the game!");
            }
            else
            {
                Console.WriteLine("Game was a draw!"); //if called earlier in the game, wont say no winner 
            }
        }
    }
}