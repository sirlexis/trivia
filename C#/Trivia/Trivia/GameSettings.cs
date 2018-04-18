using System.Collections.Generic;

namespace Trivia
{
    public class GameSettings
    {
        public GameSettings(List<Player> players, int location)
        {
            Players = players;
            Location = location;
        }

        public List<Player> Players { get; }
        public int Location { get; }
    }
}