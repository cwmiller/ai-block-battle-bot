namespace BlockBattleBot {
    public class Cell
    {
        public Position Position { get; private set; }

        public CellStatus Status { get; private set; }

        public Cell(Position position, CellStatus status)
        {
            Position = position;
            Status = status;
        }
    }
}
