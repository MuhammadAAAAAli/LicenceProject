using System;

namespace UseCases.Exception
{
    [Serializable]
    public class ChessException : System.Exception
    {
        public ChessException(string message) : base(message)
        {
        }
    }
}