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
                {
                    Console.Clear();
                    Screen.PrintBoardGame(chessGame.boardGame);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] posiblePositions = chessGame.boardGame.Piece(origin).PossibleMoves();
                    Console.Clear();
                    Screen.PrintBoardGame(chessGame.boardGame, posiblePositions);
                    
                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();
                    chessGame.ExecuteMovement(origin, destiny);
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