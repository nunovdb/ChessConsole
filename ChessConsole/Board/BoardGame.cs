using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    class BoardGame
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public BoardGame(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
            
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public bool ExistPiece(Position position) 
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position) 
        {
            if (ExistPiece(position)) 
            {
                throw new BoardException("there is already a piece in that position");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position) 
        {
            if (Piece(position) == null) 
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position) 
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) 
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position) 
        {
            if (!ValidPosition(position)) 
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
