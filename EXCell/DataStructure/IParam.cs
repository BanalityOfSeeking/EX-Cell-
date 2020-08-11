namespace EXCell.DataStructure
{
    public interface IParam
    {
        int MaxLen { get; }
        int MinLen { get; }
        string Name { get; }
        object Options { get; }
        string Value { get; }
    }
}