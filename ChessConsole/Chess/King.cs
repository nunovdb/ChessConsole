using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class King : Piece
    {
        public King(BoardGame board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
