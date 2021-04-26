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

        public void PutPiece(Piece piece, Position position) 
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
