namespace TicTacToe.Exception
{
    public class InvalidCoordinateException : System.Exception
    {
        public string ExceptionMessage { get; }
        
        public InvalidCoordinateException(string messsage)
        {
            ExceptionMessage = messsage;
        }
    }
}