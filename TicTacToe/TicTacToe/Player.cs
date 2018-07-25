using TicTacToe.Enum;

namespace TicTacToe
{
    public class Player
    {
        public int Id { get; }
        public Symbol Symbol { get; }
        
        public Player(int id, Symbol symbol)
        {
            Id = id;
            Symbol = symbol;
        }
    }
}