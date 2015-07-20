using System.Collections.Generic;

namespace BlockBattleBot
{
    public class Piece
    {
        public PieceType PieceType { get; set; }

        public int Rotations { get; set; }

        #region Piece Cells

        private static Dictionary<PieceType, byte[][,]> cells = new Dictionary<PieceType, byte[][,]>() {
            { PieceType.I, new byte[][,] { 
                new byte[,] { 
                 { 0, 0, 0, 0},
                 { 1, 1, 1, 1},
                 { 0, 0, 0, 0},
                 { 0, 0, 0, 0} },

                new byte[,] {
                 { 0, 0, 1, 0},
                 { 0, 0, 1, 0},
                 { 0, 0, 1, 0},
                 { 0, 0, 1, 0} },

                new byte[,] {
                 { 0, 0, 0, 0},
                 { 0, 0, 0, 0},
                 { 1, 1, 1, 1},
                 { 0, 0, 0, 0} },

                new byte[,] {
                 { 0, 1, 0, 0},
                 { 0, 1, 0, 0},
                 { 0, 1, 0, 0},
                 { 0, 1, 0, 0} }
            }},

            { PieceType.J, new byte[][,] {
                new byte[,] {
                  { 1, 0, 0 },
                  { 1, 1, 1 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 0, 1, 1 },
                  { 0, 1, 0 },
                  { 0, 1, 0 } },

                new byte[,] {
                  { 0, 0, 0 },
                  { 1, 1, 1 },
                  { 0, 0, 1 } },

                new byte[,] {
                  { 0, 1, 0 },
                  { 0, 1, 0 },
                  { 1, 1, 0 } }
            }},

            { PieceType.L, new byte[][,] {
                new byte[,] {
                  { 0, 0, 1 },
                  { 1, 1, 1 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 0, 1, 0 },
                  { 0, 1, 0 },
                  { 0, 1, 1 } },

                new byte[,] {
                  { 1, 1, 1 },
                  { 1, 0, 0 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 1, 1, 0 },
                  { 0, 1, 0 },
                  { 0, 1, 0 } }
            }},

            { PieceType.O, new byte[][,] {
                new byte[,] {
                  { 1, 1 },
                  { 1, 1 } }
            }},

            { PieceType.S, new byte[][,] {
                new byte[,] {
                  { 0, 1, 1 },
                  { 1, 1, 0 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 1, 0, 0 },
                  { 1, 1, 1 },
                  { 0, 0, 1 } }
            }},

            { PieceType.T, new byte[][,] {
                new byte[,] {
                  { 0, 1, 0 },
                  { 1, 1, 1 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 0, 1, 0 },
                  { 0, 1, 1 },
                  { 0, 1, 0 } },

                new byte[,] {
                  { 0, 0, 0 },
                  { 1, 1, 1 },
                  { 0, 1, 0 } },

                new byte[,] {
                  { 0, 1, 0 },
                  { 1, 1, 0 },
                  { 0, 1, 0 } }
            }},

            { PieceType.Z, new byte[][,] {
                new byte[,] {
                  { 1, 1, 0 },
                  { 0, 1, 1 },
                  { 0, 0, 0 } },

                new byte[,] {
                  { 0, 0, 1 },
                  { 0, 1, 1 },
                  { 0, 1, 0 } }
            }}
        };

        #endregion

        public Piece(PieceType type, int rotations = 0)
        {
            PieceType = type;
            Rotations = rotations;
        }

        public int MaxRotations
        {
            get
            {
                return cells[PieceType].GetLength(0);
            }
        }

        public byte[,] Cells
        {
            get
            {
                return cells[PieceType][Rotations];
            }
        }
    }
}
