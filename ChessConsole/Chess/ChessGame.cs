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
        public bool Check { get; private set; }

        public ChessGame() 
        {
            boardGame = new BoardGame(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destiny) 
        {
            Piece piece = boardGame.RemovePiece(origin);
            piece.IncreaseNumMoves();
            Piece capturedPiece = boardGame.RemovePiece(destiny);
            boardGame.PutPiece(piece, destiny);
            if (capturedPiece != null) 
            {
                Captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void MakeMove(Position origin, Position destiny) 
        {

            Piece capturedPiece = ExecuteMovement(origin, destiny);
            if (IsInCheck(actualPlayer)) 
            {
                CancelMove(origin, destiny, capturedPiece);
                throw new BoardException("you cannot put yourself in Check");
            }
            if (IsInCheck(Opponent(actualPlayer)))
            {
                Check = true;
            }
            else 
            {
                Check = false;
            }

            turn++;
            ChangePlayer();            
        }

        public void CancelMove(Position origin, Position destiny, Piece capturedPiece) 
        {
            Piece p = boardGame.RemovePiece(destiny);
            p.DecreaseNumMoves();
            if (capturedPiece != null) 
            {
                boardGame.PutPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            boardGame.PutPiece(p, origin);
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

        private Color Opponent(Color color) 
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else 
            {
                return Color.White;
            }
        }

        private Piece King(Color color) 
        {
            foreach (Piece x in PlayingPieces(color)) 
            {
                if (x is King) 
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color) 
        {
            Piece k = King(color);
            if (k == null) 
            {
                throw new BoardException("There ir no " + color + " king!");
            }
            foreach (Piece x in PlayingPieces(Opponent(color))) 
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[k.Position.Line, k.Position.Column] ) 
                {
                    return true;
                }
            }
            return false;

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
