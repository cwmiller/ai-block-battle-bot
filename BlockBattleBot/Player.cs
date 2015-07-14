using System.Collections.Generic;

namespace BlockBattleBot
{
    public class Player
    {
        public int Points { get; set; }

        public int Combo { get; set; }

        public List<Cell> Cells { get; set; }

        public Player()
        {
            Points = 0;
            Combo = 0;
            Cells = new List<Cell>();
        }

        public Player(int points, int combo, List<Cell> cells)
        {
            Points = points;
            Combo = combo;
            Cells = cells;
        }
    }
}
