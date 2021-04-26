using ChessConsole.Board;
using System;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p;

            p = new Position(3, 4);

            Console.WriteLine("Position:" + p);
        }
    }
}
