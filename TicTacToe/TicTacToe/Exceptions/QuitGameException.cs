namespace TicTacToe.Exception
{
    public class QuitGameException : System.Exception
    {
        public string ExceptionMessage { get; }

        public QuitGameException(string messsage)
        {
            ExceptionMessage = messsage;
        }
    }
}