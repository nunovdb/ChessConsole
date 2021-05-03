using System;
using System.Collections.Generic;
using System.Text;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class ChessGame
    {
        public BoardGame boardGame { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
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

        public void MakeMove(Position origin, Position destiny) 
        {
            ExecuteMovement(origin, destiny);
            turn++;
            ChangePlayer();
            
        }

        public void ValidatePositionOrigin(Position origin) 
        {
            if (boardGame.Piece(origin) == null) 
            {
                throw new BoardException("There are no pieces in the chosen position!");
            }
            if (actualPlayer != boardGame.Piece(origin).Color) 
            {
                throw new BoardException("The piece in the chosen position is not yours!");
            }
            if (!boardGame.Piece(origin).ExistPossibleMoves()) 
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }

        }
        public void ValidatePositionDestiny(Position origin, Position destiny)
        {
            if (!boardGame.Piece(origin).CanMoveTo(destiny)) 
            {
                throw new BoardException("You cannot move this piece to that destination!");
            }

        }

        private void ChangePlayer() 
        {
            if (actualPlayer == Color.White)
            {
                actualPlayer = Color.Black;
            }
            else 
            {
                actualPlayer = Color.White;
            }

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
