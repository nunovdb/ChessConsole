using System;
using ChessConsole.Board;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintBoardGame(BoardGame boardGame) 
        {
            for (int i = 0; i < boardGame.Lines; i++) 
            {
                for (int j = 0; j < boardGame.Columns; j++)
                {
                    if (boardGame.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(boardGame.Piece(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
