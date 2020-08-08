namespace EXCell.DataStructure
{
    public interface ICell
    {
        string Name { get; }
        string Value { get; set; }
        object Options { get; }

        bool Equals(Cell other);

        bool Equals(object obj);

        bool Equals(object x, object y);

        int GetHashCode();

        int GetHashCode(object obj);
    }
}