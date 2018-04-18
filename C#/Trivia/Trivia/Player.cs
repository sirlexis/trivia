namespace Trivia
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Purse = 0;
            Location = 0;
            IsInPenaltyBox = false;
        }

        public string Name { get; }
        public int Purse { get; }
        public int Location { get; }
        public bool IsInPenaltyBox { get; }
    }
}