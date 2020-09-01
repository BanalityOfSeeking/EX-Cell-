namespace EXCell
{
    public class GamePools : IPoolGameObjects
    {
        public IGamePool<Player> PlayerPool { get; } = new GamePool<Player>();

        public IGamePool<Monster> MonstePool { get; } = new GamePool<Monster>();
    }
}