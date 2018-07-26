using TicTacToe.Enum;

namespace TicTacToe
{
    public class PlayerMove 
    {
        public Player Player { get;  }
        public Coordinates Coordinates { get; }

        public PlayerMove(Player player, Coordinates coordinates)
        {
            Player = player;
            Coordinates = coordinates;
        }
    }
}