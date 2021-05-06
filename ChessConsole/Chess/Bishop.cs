using System;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class Bishop : Piece
    {
        public Bishop(BoardGame boardGame, Color color) : base(boardGame, color)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // NO
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.Line - 1, Position.Column - 1);
            }

            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.Line - 1, Position.Column + 1);
            }

            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.Line + 1, Position.Column + 1);
            }

            // SO
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.Line + 1, Position.Column + 1);
            }

            return mat;
        }
    }
}
