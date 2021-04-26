using ChessConsole.Board;
using System;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessPosition pos = new ChessPosition('a', 1);
            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosition());

            Console.ReadLine();
        }
    }
}
