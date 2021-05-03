using System;
using ChessConsole.Board;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintBoardGame(BoardGame boardGame) 
        {
            for (int i = 0; i < boardGame.Lines; i++) 
            {
                Console.Write( 8 - i + " " );
                for (int j = 0; j < boardGame.Columns; j++)
                {
                    PrintPiece(boardGame.Piece(i,j));                       
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoardGame(BoardGame boardGame, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alternateBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < boardGame.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < boardGame.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alternateBackground;

                    }
                    else 
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(boardGame.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }


        public static ChessPosition ReadChessPosition() 
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);
        }
        public static void PrintPiece(Piece piece) 
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
