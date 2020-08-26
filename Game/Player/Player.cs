namespace EXCell
{
    public class Player : IPlayer
    {
        public Player()
        {
            Name = default;
            Health = 100;
        }

        public string Name { get; internal set; }

        public int Health { get; }

        public Player SetPlayerName(string name)
        {
            Name = name;
            return this;
        }

    }
}