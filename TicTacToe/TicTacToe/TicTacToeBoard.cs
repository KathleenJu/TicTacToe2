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

        public TicTacToeBoard(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            PlayedCoordinates = new List<Coordinates>();
        }

        public bool PlayPiece(Coordinates coordinates)
        {
            throw new System.NotImplementedException();
        }

        public GameStatus GetGameStatus()
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public bool ResetBoard()
        {
            PlayedCoordinates.Clear();
            return PlayedCoordinates.Count == 0;
        }

        public List<Coordinates> GetPlayedCoordinates()
        {
            return PlayedCoordinates;
        }
    }
}