using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMoves { get; set; }
        public BoardGame Board { get; set; }

        public Piece(BoardGame board, Color color)
        {
            Position = null;
            Color = color;
            NumMoves = 0; // the Piece has not yet been moved
            Board = board;
        }

        public void IncreaseNumMoves() 
        {
            NumMoves++;
        }
    }
}
