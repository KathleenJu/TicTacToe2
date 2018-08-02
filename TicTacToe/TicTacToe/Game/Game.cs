using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enum;
using TicTacToe.Exception;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public class Game
    {
        public Board GameBoard { get; private set; }
        public List<Player> GamePlayers { get; }
        public Player CurrentPlayer { get; protected set; }
        public IGameRules GameRules { get; }
        public GameStatus GameStatus { get; private set; }

        public Game(IGameRules gameRules)
        {
            GameRules = gameRules;
            GameBoard = new Board();
            GamePlayers = new List<Player>();
            GameStatus = GameStatus.PLAYING;
        }

        public void PlayMove(PlayerMove playerMove)
        {
            GameBoard.UpdateBoard(playerMove);
        }

        public bool IsGameOver()
        {
            return GameRules.HasWinner(GameBoard) || IsDrawGame();
        }

        private bool IsDrawGame()
        {
            var fullBoard = GameBoard.PlayedMoves.Count() == GameBoard.BoardSize * GameBoard.BoardSize;
            return fullBoard;
        }

        public Player GetWinner()
        {
            return GameRules.HasWinner(GameBoard) ? GameBoard.PlayedMoves.Last().Player : null;
        }

        public void EndGame()
        {
            GameStatus = GameStatus.OVER;
        }

        public void SetGameBoard(int boardSize)
        {
            GameBoard = new Board(boardSize);
        }

        public void StartGame()
        {
            GameStatus = GameStatus.PLAYING;
        }

        public void AddPlayerToGame(Player player)
        {
            if (!GamePlayers.Any(gamePlayer => gamePlayer.Mark == player.Mark))
            {
                GamePlayers.Add(player);
            }
            else
            {
                throw new System.Exception("Mark already taken.");
            }
        }

        public void SetCurrentPlayer(Player player)
        {
            CurrentPlayer = player;
        }
    }
}