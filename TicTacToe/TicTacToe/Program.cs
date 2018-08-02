using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new TicTacToeRules());
            var consoleRenderer = new consoleRenderer();
            var x = new X(game, consoleRenderer);
            x.play();     
        }
    }

    class X
    {
        private readonly IRenderer Renderer;
        private readonly Game Game;
             
        public X(Game game, IRenderer renderer)
        {
            Renderer = renderer;
            Game = game;
        }

        public void play()
        {
            Game.StartGame();
            Renderer.RenderMessage("Welcome to Tic Tac Toe! \n");
            Renderer.RenderGameBoard(Game.GameBoard);

            var boardSize = Renderer.GetBoardSize();
            Game.SetGameBoard(boardSize);
            Renderer.RenderMessage("Here's the current board: \n");
            Renderer.RenderGameBoard(Game.GameBoard);

            var player1 = Renderer.GetPlayerMark(Game.GamePlayers);
            Game.AddPlayerToGame(player1);
            var player2 = Renderer.GetPlayerMark(Game.GamePlayers);
            Game.AddPlayerToGame(player2);
            Game.SetCurrentPlayer(player1);
            

            while (Game.GameStatus != GameStatus.OVER)
            {
                try
                {
                    Game.PlayMove(Renderer.GetPlayerMove(Game.CurrentPlayer));
                }
                catch (InvalidCoordinateException ex)
                {
                    Renderer.RenderMessage(ex.ExceptionMessage);
                    return;
                }
                catch (QuitGameException ex)
                {
                    Renderer.RenderMessage(ex.ExceptionMessage);
                    return;
                }

                Renderer.RenderMessage("Move accepted, here's the current board: \n");
                Renderer.RenderGameBoard(Game.GameBoard);
                if (Game.IsGameOver())
                {
                    Game.EndGame();
                    Renderer.RenderWinner(Game.GetWinner());
                }

                var newCurrentPlayer = Game.GamePlayers.Where(player => player != Game.CurrentPlayer).Select(player => player).First();
                Game.SetCurrentPlayer(newCurrentPlayer);
            }
        }  
    }
}