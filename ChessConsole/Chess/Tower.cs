using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class Tower : Piece
    {
        public Tower(BoardGame board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "T";
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

            // up
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color) 
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // down
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            
            // Right
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            // Left
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (BoardGame.Piece(pos) != null && BoardGame.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }


            return mat;
        }


    }
}
