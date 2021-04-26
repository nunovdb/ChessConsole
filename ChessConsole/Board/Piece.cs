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

        public Piece(Position position, Color color, int numMoves, BoardGame board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumMoves = 0; // the Piece has not yet been moved 
        }
    }
}
