namespace BlockBattleBot
{
    public class Round
    {
        public int Number { get; set; }

        public PieceType Piece { get; set; }

        public PieceType NextPiece { get; set; }

        public Position PiecePosition { get; set; }

        public Round()
        {
            Number = 0;
            Piece = PieceType.I;
            NextPiece = PieceType.I;
            PiecePosition = new Position(0, 0);
        }

        public Round(int number, PieceType piece, PieceType nextPience, Position piecePosition)
        {
            Number = number;
            Piece = piece;
            NextPiece = nextPience;
            PiecePosition = piecePosition;
        }
    }
}
