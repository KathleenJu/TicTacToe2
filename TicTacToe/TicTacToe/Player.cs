using TicTacToe.Enum;

namespace TicTacToe
{
    public class Player
    {
        public int Id { get; }
        public char Mark { get; }
        
        public Player(int id, char mark)
        {
            Id = id;
            Mark = mark;
        }
    }
}