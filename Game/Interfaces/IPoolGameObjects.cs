namespace EXCell
{
    public interface IPoolGameObjects
    {
        IGamePool<Player> PlayerPool { get; } 
        IGamePool<Monster> MonstePool { get; }
    }
}