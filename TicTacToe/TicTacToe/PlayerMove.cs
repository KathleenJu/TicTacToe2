using TicTacToe.Enum;

namespace TicTacToe
{
    public class PlayerMove //state?, 
    {
        private readonly Symbol Symbol;
        private readonly Coordinates Coordinates;

        public PlayerMove(Symbol symbol, Coordinates coordinates)
        {
            Symbol = symbol;
            Coordinates = coordinates;
        }

        public Coordinates GetCoordinates()
        {
            return Coordinates;
        }
    }
}