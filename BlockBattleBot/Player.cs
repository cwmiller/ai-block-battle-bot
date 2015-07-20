namespace BlockBattleBot
{
    public class Player
    {
        public int Points { get; set; }

        public int Combo { get; set; }

        public Field Field { get; private set; }

        public Player()
        {
            Points = 0;
            Combo = 0;
            Field = new Field(0, 0);
        }

        public Player(int points, int combo, Field field)
        {
            Points = points;
            Combo = combo;
            Field = field;
        }
    }
}
