using System;

namespace ChessConsole.Board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message) 
        {
        }
    }
}
