using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeBoard
    {
        private List<Coordinates> GameBoard;
        private int BoardHeight;
        private int BoardWidth;

        public TicTacToeBoard(int boardHeight, int boardWidth)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            SetUpGameBoard();
        }

        public void SetUpGameBoard()
        {
            
        }
    }
}