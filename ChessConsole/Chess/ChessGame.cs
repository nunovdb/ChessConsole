using System;
using System.Collections.Generic;
using System.Text;
using ChessConsole.Board;

namespace ChessConsole.Chess
{
    class ChessGame
    {
        public BoardGame BoardGame { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Terminated { get; private set; }        
        
        private HashSet<Piece> Pieces;        

        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessGame() 
        {
            BoardGame = new BoardGame(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destiny) 
        {
            Piece piece = BoardGame.RemovePiece(origin);
            piece.IncreaseNumMoves();
            Piece capturedPiece = BoardGame.RemovePiece(destiny);
            BoardGame.PutPiece(piece, destiny);
            if (capturedPiece != null) 
            {
                Captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void MakeMove(Position origin, Position destiny) 
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);

            if (IsInCheck(ActualPlayer)) 
            {
                CancelMove(origin, destiny, capturedPiece);
                throw new BoardException("you cannot put yourself in Check");
            }
            if (IsInCheck(Opponent(ActualPlayer)))
            {
                Check = true;
            }
            else 
            {
                Check = false;
            }

            if (CheckmateTest(Opponent(ActualPlayer)))
            {
                Terminated = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        public void CancelMove(Position origin, Position destiny, Piece capturedPiece) 
        {
            Piece p = BoardGame.RemovePiece(destiny);
            p.DecreaseNumMoves();
            if (capturedPiece != null) 
            {
                BoardGame.PutPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }

            BoardGame.PutPiece(p, origin);
        }

        public void ValidatePositionOrigin(Position origin) 
        {
            if (BoardGame.Piece(origin) == null) 
            {
                throw new BoardException("There are no pieces in the chosen position!");
            }
            if (ActualPlayer != BoardGame.Piece(origin).Color) 
            {
                throw new BoardException("The piece in the chosen position is not yours!");
            }
            if (!BoardGame.Piece(origin).ExistPossibleMoves()) 
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }

        public void ValidatePositionDestiny(Position origin, Position destiny)
        {
            if (!BoardGame.Piece(origin).PossibleMove(destiny)) 
            {
                throw new BoardException("You cannot move this piece to that destination!");
            }
        }

        private void ChangePlayer() 
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else 
            {
                ActualPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured) 
            {
                if (x.Color == color) 
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PlayingPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color) 
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else 
            {
                return Color.White;
            }
        }

        private Piece King(Color color) 
        {
            foreach (Piece x in PlayingPieces(color)) 
            {
                if (x is King) 
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color) 
        {
            Piece k = King(color);
            if (k == null) 
            {
                throw new BoardException("There ir no " + color + " king!");
            }
            foreach (Piece x in PlayingPieces(Opponent(color))) 
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[k.Position.Line, k.Position.Column] ) 
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece x in PlayingPieces(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 1; i< x.BoardGame.Lines; i++)
                {
                    for (int j = 0; j< x.BoardGame.Columns; j++)
                    {
                        if (mat[i,j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i,j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool checkTest = IsInCheck(color);
                            CancelMove(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }    
            }

            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece) 
        {
            BoardGame.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces() 
        {
            // Move test
            //PutNewPiece('c', 1, new Tower(BoardGame, Color.White));
            //PutNewPiece('c', 2, new Tower(BoardGame, Color.White));
            //PutNewPiece('d', 2, new Tower(BoardGame, Color.White));
            //PutNewPiece('e', 2, new Tower(BoardGame, Color.White));
            //PutNewPiece('e', 1, new Tower(BoardGame, Color.White));
            //PutNewPiece('d', 1, new King(BoardGame, Color.White));

            //PutNewPiece('c', 7, new Tower(BoardGame, Color.Black));
            //PutNewPiece('c', 8, new Tower(BoardGame, Color.Black));
            //PutNewPiece('d', 7, new Tower(BoardGame, Color.Black));
            //PutNewPiece('e', 7, new Tower(BoardGame, Color.Black));
            //PutNewPiece('e', 8, new Tower(BoardGame, Color.Black));
            //PutNewPiece('d', 8, new King(BoardGame, Color.Black));

            // Checkmate test
            PutNewPiece('c', 1, new Tower(BoardGame, Color.White));
            PutNewPiece('h', 7, new Tower(BoardGame, Color.White));
            PutNewPiece('d', 1, new King(BoardGame, Color.White));

            PutNewPiece('b', 8, new Tower(BoardGame, Color.Black));
            PutNewPiece('a', 8, new King(BoardGame, Color.Black));

        }


    }
}
