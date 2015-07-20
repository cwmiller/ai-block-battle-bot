using System;
namespace BlockBattleBot
{
    public class Field
    {

        public CellStatus[,] Cells { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Field(int width, int height)
        {
            Reset(width, height);
        }

        public void Reset(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new CellStatus[height, width];

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    Cells[r, c] = CellStatus.Empty;
                }
            }
        }

        public void SetCell(int x, int y, CellStatus status)
        {
            // Ignore a status of Shape.
            Cells[y, x] = status == CellStatus.Shape ? CellStatus.Empty : status;
        }

        public bool CanFit(Piece piece, Position position)
        {
            byte[,] pieceCells = piece.Cells; // ... but who's buying?

            int pieceHeight = pieceCells.GetLength(0);
            int pieceWidth = pieceCells.GetLength(1);

            for (int pieceY = 0; pieceY < pieceHeight; pieceY++)
            {
                for (int pieceX = 0; pieceX < pieceWidth; pieceX++)
                {
                    int gridY = pieceY + position.Y;
                    int gridX = pieceX + position.X;

                    if ((pieceCells[pieceY, pieceX] == 1) && (GetCell(gridX, gridY) != CellStatus.Empty))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public CellStatus GetCell(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                return CellStatus.Solid;
            }

            if (y < 0 || y >= Height)
            {
                return CellStatus.Solid;
            }

            return Cells[y, x];
        }

        public void AddPiece(Piece piece, Position position)
        {
            byte[,] pieceCells = piece.Cells; // ... but who's buying?

            int pieceHeight = pieceCells.GetLength(0);
            int pieceWidth = pieceCells.GetLength(1);

            for (int pieceY = 0; pieceY < pieceHeight; pieceY++)
            {
                for (int pieceX = 0; pieceX < pieceWidth; pieceX++)
                {
                    int gridY = pieceY + position.Y;
                    int gridX = pieceX + position.X;

                    if (pieceCells[pieceY, pieceX] == 1)
                    {
                        Cells[gridY, gridX] = CellStatus.Shape;
                    }
                }
            }
        }
    }
}
