using TicTacToe.Enum;

namespace TicTacToe
{
    public class PlayerMove //state?, 
    {
        public readonly Symbol Symbol;
        private readonly Coordinates Coordinates;
        public bool IsWinningMove { get; set; }

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