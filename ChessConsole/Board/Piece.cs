using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMoves { get; set; }
        public BoardGame BoardGame { get; set; }

        public Piece(BoardGame boardGame, Color color)
        {
            Position = null;
            Color = color;
            NumMoves = 0; // the Piece has not yet been moved
            BoardGame = boardGame;
        }

        public void IncreaseNumMoves() 
        {
            NumMoves++;
        }

        public abstract bool[,] PossibleMoves(); 
    }
}
