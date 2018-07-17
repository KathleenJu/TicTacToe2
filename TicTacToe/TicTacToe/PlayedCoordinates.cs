using TicTacToe.Enum;

namespace TicTacToe
{
    public class PlayedCoordinates
    {
        private Symbol Symbol;
        private Coordinates Coordinates;

        public PlayedCoordinates(Symbol symbol, Coordinates coordinates)
        {
            Symbol = symbol;
            Coordinates = coordinates;
        }
    }
}