using System;
using System.Collections.Generic;
using System.Text;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class ChessGame
    {
        public BoardGame boardGame { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool Terminada { get; private set; }

        public ChessGame() 
        {
            boardGame = new BoardGame(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny) 
        {
            Piece piece = boardGame.RemovePiece(origin);
            piece.IncreaseNumMoves();
            Piece capturedPiece = boardGame.RemovePiece(destiny);
            boardGame.PutPiece(piece, destiny);
        }

        private void PutPieces() 
        {
            boardGame.PutPiece(new Tower(boardGame, Color.White), new ChessPosition('c', 1).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.White), new ChessPosition('c', 2).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.White), new ChessPosition('d', 2).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.White), new ChessPosition('e', 2).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.White), new ChessPosition('e', 1).ToPosition());
            boardGame.PutPiece(new King(boardGame, Color.White), new ChessPosition('d', 1).ToPosition());

            boardGame.PutPiece(new Tower(boardGame, Color.Black), new ChessPosition('c', 7).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.Black), new ChessPosition('c', 8).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.Black), new ChessPosition('d', 7).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.Black), new ChessPosition('e', 7).ToPosition());
            boardGame.PutPiece(new Tower(boardGame, Color.Black), new ChessPosition('e', 8).ToPosition());
            boardGame.PutPiece(new King(boardGame, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
