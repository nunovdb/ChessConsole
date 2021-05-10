using System;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class Pawn : Piece
    {
        public Pawn(BoardGame boardGame, Color color) : base(boardGame, color)
        {
        }


        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position position)
        {
            Piece piece = BoardGame.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return BoardGame.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[BoardGame.Lines, BoardGame.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (BoardGame.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (BoardGame.ValidPosition(pos) && Free(pos) && NumMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (BoardGame.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (BoardGame.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (BoardGame.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (BoardGame.ValidPosition(pos) && Free(pos) && NumMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (BoardGame.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (BoardGame.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
