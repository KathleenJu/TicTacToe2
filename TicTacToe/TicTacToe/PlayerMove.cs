using TicTacToe.Enum;

namespace TicTacToe
{
    public class PlayerMove 
    {
        public Symbol Symbol { get; }
        public Coordinates Coordinates { get; }

        public PlayerMove(Symbol symbol, Coordinates coordinates)
        {
            Symbol = symbol;
            Coordinates = coordinates;
        }
    }
}