namespace BlockBattleBot
{
    public class Round
    {
        public int Number { get; set; }

        public Piece Piece { get; set; }

        public Piece NextPiece { get; set; }

        public Position PiecePosition { get; set; }

        public Round()
        {
            Number = 0;
            Piece = Piece.I;
            NextPiece = Piece.I;
            PiecePosition = new Position(0, 0);
        }

        public Round(int number, Piece piece, Piece nextPience, Position piecePosition)
        {
            Number = number;
            Piece = piece;
            NextPiece = nextPience;
            PiecePosition = piecePosition;
        }
    }
}
