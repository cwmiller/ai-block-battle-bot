using System.Collections.Generic;

namespace BlockBattleBot
{
    public class Game
    {
        public Settings Settings { get; set; }

        public IDictionary<string, Player> Players { get; set; }

        public string PlayerName { get; set; }

        public Round Round { get; set; }

        public Game()
        {
            Settings = new Settings();
            Players = new Dictionary<string, Player>();
            Round = new Round();
            PlayerName = "";
        }

        public Game(Settings settings, IDictionary<string, Player> players, string playerName, Round round)
        {
            Settings = settings;
            Players = players;
            PlayerName = playerName;
            Round = round;
        }
    }
}
