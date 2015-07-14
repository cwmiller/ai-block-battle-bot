using System;
using System.Collections.Generic;

namespace BlockBattleBot
{
    public class Brain
    {
        public Game Game { get; private set; }

        public Brain(Game game)
        {
            Game = game;
        }

        public Move[] Moves(int time)
        {
            // AI logic goes here

            return new Move[] { Move.Drop };
        }
    }
}
