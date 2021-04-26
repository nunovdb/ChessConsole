using ChessConsole.Board;
using System;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            BoardGame boardGame = new BoardGame(8,8);

            boardGame.PutPiece(new Tower(boardGame, Color.Black), new Position(0,0));
            boardGame.PutPiece(new Tower(boardGame, Color.Black), new Position(1,3));
            boardGame.PutPiece(new King(boardGame, Color.Black), new Position(2,4));

            Screen.PrintBoardGame(boardGame);

            Console.ReadLine();
        }
    }
}
