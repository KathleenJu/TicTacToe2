using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : IGameBoard
    {
        private readonly List<PlayedCoordinates> PlayedCoordinates; 
        private int BoardHeight;
        private int BoardWidth;
        private GameStatus GameStatus;

        public TicTacToeBoard(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            PlayedCoordinates = new List<PlayedCoordinates>();
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayPiece(PlayedCoordinates playedCoordinates)
        {
            if (IsEmptyPosition(playedCoordinates))
            {
                PlayedCoordinates.Add(playedCoordinates);
                return true;
            }
            return false;
        }

        private bool IsEmptyPosition(PlayedCoordinates playerCoordinates)
        {
            return !PlayedCoordinates.Contains(playerCoordinates);
        }

        public GameStatus GetGameStatus()
        {
            return GameStatus;
        }

        public void StartGame()
        {
            ResetBoard();
        }

        public bool ResetBoard()
        {
            PlayedCoordinates.Clear();
            GameStatus = GameStatus.OVER;
            return PlayedCoordinates.Count == 0;
        }

        public List<PlayedCoordinates> GetPlayedCoordinates()
        {
            return PlayedCoordinates;
        } 
    }
}