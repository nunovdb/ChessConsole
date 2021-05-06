using System;
using System.Collections.Generic;
using ChessConsole.Board;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintChessGame(ChessGame chessGame) 
        {
            PrintBoardGame(chessGame.BoardGame);
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessGame.Turn);
            if (!chessGame.Terminated)
            {
                Console.WriteLine("Waiting for the move: " + chessGame.ActualPlayer);
                if (chessGame.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!!");
                Console.WriteLine("Winner: " + chessGame.ActualPlayer);
            }
        }

        public static void PrintCapturedPieces(ChessGame chessGame) 
        {
            Console.WriteLine("Captured Pieces");
            Console.Write("White: ");
            PrintGroup(chessGame.CapturedPieces(Color.White));
            Console.WriteLine();
            
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(chessGame.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> group) 
        {
            Console.Write("[");
            foreach (Piece x in group) 
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }


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
