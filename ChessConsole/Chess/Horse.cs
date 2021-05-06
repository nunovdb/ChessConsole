using System;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class Horse : Piece
    {
        public Horse(BoardGame boardGame, Color color) : base(boardGame, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position position)
        {
            Piece piece = BoardGame.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[BoardGame.Lines, BoardGame.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
