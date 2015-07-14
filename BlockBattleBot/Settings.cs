namespace BlockBattleBot
{
    public class Settings
    {
        public int MaxTimeBank { get; set; }

        public int TimePerMove { get; set; }

        public int FieldWidth { get; set; }

        public int FieldHeight { get; set; }

        public Settings()
        {
        }

        public Settings(int maxTimeBank, int timePerMove, int fieldWidth, int fieldHeight)
        {
            MaxTimeBank = maxTimeBank;
            TimePerMove = timePerMove;
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
        }
    }
}
