using System.Collections.Generic;
using System.Data;
using System.Linq;
using TicTacToe.Enum;

namespace TicTacToe
{
    public class TicTacToeBoard : IGameBoard
    {
        private List<Coordinates> PlayedCoordinates; 
        private int BoardHeight;
        private int BoardWidth;
        private GameStatus GameStatus;

        public TicTacToeBoard(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            PlayedCoordinates = new List<Coordinates>();
            GameStatus = GameStatus.PLAYING;
        }

        public bool PlayPiece(Coordinates coordinates)
        {
            if (IsEmptyPosition(coordinates))
            {
                PlayedCoordinates.Add(coordinates);
                return true;
            }
            return false;
        }

        private bool IsEmptyPosition(Coordinates coordinates)
        {
            return !PlayedCoordinates.Contains(coordinates);
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

        public List<Coordinates> GetPlayedCoordinates()
        {
            return PlayedCoordinates;
        }
    }
}