using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class King : Piece
    {
        public King(BoardGame boardGame, Color color) : base(boardGame, color)
        {
        }

        public override string ToString()
        {
            return "K";
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

            // N (UP)
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (BoardGame.ValidPosition(pos) && CanMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }
            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // E
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // S
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // SW
            pos.DefineValues(Position.Line + 1, Position.Column -1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // SW
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // NW
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (BoardGame.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
