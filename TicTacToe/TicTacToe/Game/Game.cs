using TicTacToe.Enum;
using TicTacToe.GameRules;

namespace TicTacToe
{
    public abstract class Game
    {
        
        public TicTacToeBoard GameBoard { get; }
        public TicTacToeRules GameRules { get; }
        public GameStatus GameStatus { get; protected set; }

        protected Game(Board gameBoard, IGameRules gameRules)
        {
            GameBoard = (TicTacToeBoard) gameBoard;
            GameRules = (TicTacToeRules) gameRules;
            GameStatus = GameStatus.PLAYING;
        }
    } 
}