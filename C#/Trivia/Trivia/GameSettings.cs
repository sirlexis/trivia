using System.Collections.Generic;

namespace Trivia
{
    public class GameSettings
    {
        public GameSettings(List<Player> players, Location maxNoPlaces)
        {
            Players = players;
            MaxNoPlaces = maxNoPlaces;
        }

        public List<Player> Players { get; }
        public Location MaxNoPlaces { get; }
    }
}