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
        private HashSet<Piece> Pieces;        
        private HashSet<Piece> Captured;

        public ChessGame() 
        {
            boardGame = new BoardGame(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny) 
        {
            Piece piece = boardGame.RemovePiece(origin);
            piece.IncreaseNumMoves();
            Piece capturedPiece = boardGame.RemovePiece(destiny);
            boardGame.PutPiece(piece, destiny);
            if (capturedPiece != null) 
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured) 
            {
                if (x.Color == color) 
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PlayingPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PutNewPiece(char column, int line, Piece piece) 
        {
            boardGame.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces() 
        {
            PutNewPiece('c', 1, new Tower(boardGame, Color.White));
            PutNewPiece('c', 2, new Tower(boardGame, Color.White));
            PutNewPiece('d', 2, new Tower(boardGame, Color.White));
            PutNewPiece('e', 2, new Tower(boardGame, Color.White));
            PutNewPiece('e', 1, new Tower(boardGame, Color.White));
            PutNewPiece('d', 1, new King(boardGame, Color.White));

            PutNewPiece('c', 7, new Tower(boardGame, Color.Black));
            PutNewPiece('c', 8, new Tower(boardGame, Color.Black));
            PutNewPiece('d', 7, new Tower(boardGame, Color.Black));
            PutNewPiece('e', 7, new Tower(boardGame, Color.Black));
            PutNewPiece('e', 8, new Tower(boardGame, Color.Black));
            PutNewPiece('d', 8, new King(boardGame, Color.Black));
        }
    }
}
