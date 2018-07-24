using TicTacToe.Enum;

namespace TicTacToe
{
    public class Player
    {
        public Player(int id, Symbol symbol)
        {
            Id = id;
            Symbol = symbol;
        }

        public int Id { get; }
        public Symbol Symbol { get; }
    }
}