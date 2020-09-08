namespace Game.DataStructure
{
    public interface IGameCell
    {
        public string Name { get; }
        public object Value { get; set; }
        public object Options { get; }

        bool Equals(IGameCell other);

        bool Equals(object obj);

        bool Equals(object x, object y);

        int GetHashCode();

        int GetHashCode(object obj);
    }
}