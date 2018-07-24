namespace TicTacToe.Exception
{
    public class InvalidCoordinateFormatException : System.Exception
    {
        public InvalidCoordinateFormatException()
        {
        }

        public InvalidCoordinateFormatException(string message)
            : base(message)
        {
        } 
    }
}