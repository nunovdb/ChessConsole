using ChessConsole.Board;
using System;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame chessGame = new ChessGame();
                while (!chessGame.Terminada) 
                { try
                    {
                        Console.Clear();
                        Screen.PrintChessGame(chessGame);

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        chessGame.ValidatePositionOrigin(origin);

                        bool[,] posiblePositions = chessGame.boardGame.Piece(origin).PossibleMoves();
                        Console.Clear();
                        Screen.PrintBoardGame(chessGame.boardGame, posiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        chessGame.ValidatePositionDestiny(origin, destiny);

                        chessGame.MakeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }               
            }
            catch (BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}