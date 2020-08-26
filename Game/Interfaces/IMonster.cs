namespace EXCell
{
    public interface IMonster
    {
        string Name { get; }
        int Health { get; }
        bool IsAlive { get; }
        bool HasTreasure { get; }
        int TreasureCode { get; }
    }
}