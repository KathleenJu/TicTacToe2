using System.Collections.Generic;
using System.Linq;
using TicTacToe;

namespace TicTacToeTests
{
    public class GameStatusChecker
    {
        private readonly List<PlayerMove> PlayedMoves;

        private readonly List<List<Coordinates>> WinningLines = new List<List<Coordinates>>();


        public GameStatusChecker(List<PlayerMove> playedMoves)
        {
            PlayedMoves = playedMoves;
        }

//        public void FindHorizontalWinningLines()
//        {
//            var coordinates = new List<Coordinates>();
//            coordinates = PlayedMoves.Select(x => x.GetCoordinates()).ToList();
//            int boardHeight = 3;
//            int boardWidth = 3;
//            var lines = new List<Coordinates>();
//            for(int row = 1; row < boardHeight + 1; row++)
//            {
//                lines = coordinates.Where(c => c.GetRow() == row)
//                    .Select(x => x).ToList(); 
//            }
//        }
    }
}