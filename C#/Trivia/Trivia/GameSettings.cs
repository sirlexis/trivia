using System.Collections.Generic;

namespace Trivia
{
    public class GameSettings
    {
        public GameSettings(Location maxNoPlaces)
        {
            MaxNoPlaces = maxNoPlaces;
        }

        public GameSettings(Location numberOfLocations, HashSet<Category> categories)
        {
            MaxNoPlaces = numberOfLocations;
            Categories = categories;
        }


        public Location MaxNoPlaces { get; }
        public HashSet<Category> Categories { get; }
    }
}