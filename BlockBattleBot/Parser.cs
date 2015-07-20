using System;
using System.Linq;

namespace BlockBattleBot
{
    public class Parser
    {
        public Game Game { get; private set; }

        public Brain Brain { get; private set; }

        public Parser(Game game, Brain brain)
        {
            Game = game;
            Brain = brain;
        }

        public object Parse(string line)
        {
            string response = null;

            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] segments = line.Split(' ');

                if (segments.Length < 3)
                {
                    throw new Exception(string.Format("Expected 3 segments, got {0}.", segments.Length));
                }

                switch (segments[0])
                {
                    case "settings":
                        switch (segments[1])
                        {
                            case "timebank":
                                Game.Settings.MaxTimeBank = Convert.ToInt32(segments[2]);
                                break;
                            case "time_per_move":
                                Game.Settings.TimePerMove = Convert.ToInt32(segments[2]);
                                break;
                            case "player_names":
                                Game.Players.Clear();
                                string[] names = segments[2].Split(',');
                                foreach (var name in names)
                                {
                                    Game.Players.Add(name, new Player(0, 0, new Field(Game.Settings.FieldWidth, Game.Settings.FieldHeight)));
                                }
                                break;
                            case "your_bot":
                                Game.PlayerName = segments[2];
                                break;
                            case "field_width":
                                Game.Settings.FieldWidth = Convert.ToInt32(segments[2]);
                                break;
                            case "field_height":
                                Game.Settings.FieldHeight = Convert.ToInt32(segments[2]);
                                break;
                        }
                        break;

                    case "update":
                        if (segments[1] == "game")
                        {
                            switch (segments[2])
                            {
                                case "round":
                                    Game.Round.Number = Convert.ToInt32(segments[3]);
                                    break;
                                case "this_piece_type":
                                    Game.Round.Piece = (PieceType)Enum.Parse(typeof(PieceType), segments[3]);
                                    break;
                                case "next_piece_type":
                                    Game.Round.NextPiece = (PieceType)Enum.Parse(typeof(PieceType), segments[3]);
                                    break;
                                case "this_piece_position":
                                    int[] points = segments[3].Split(',').Select(point => Convert.ToInt32(point)).ToArray();
                                    Game.Round.PiecePosition = new Position(points[0], points[1]);
                                    break;
                            }
                        }
                        else
                        {
                            switch (segments[2])
                            {
                                case "row_points":
                                    Game.Players[segments[1]].Points = Convert.ToInt32(segments[3]);
                                    break;
                                case "combo":
                                    Game.Players[segments[1]].Combo = Convert.ToInt32(segments[3]);
                                    break;
                                case "field":
                                    Game.Players[segments[1]].Field.Reset(Game.Settings.FieldWidth, Game.Settings.FieldHeight);

                                    string[] rows = segments[3].Trim(';').Split(';');

                                    for (int y = 0; y < rows.Length; y++)
                                    {
                                        string[] columns = rows[y].Split(',');
                                        for (int x = 0; x < columns.Length; x++)
                                        {
                                            CellStatus status = (CellStatus)Enum.Parse(typeof(CellStatus), columns[x]);
                                            Game.Players[segments[1]].Field.SetCell(x, y, status);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;

                    case "action":
                        if (segments[1] == "moves")
                        {
                            response = string.Join(",", Brain.Moves(Convert.ToInt32(segments[2])).Select(m => m.ToString().ToLower()));
                        }
                        break;

                    default:
                        throw new Exception(string.Format("Unknown command: {0}.", segments[0]));
                }
            }

            return response;
        }
    }
}
