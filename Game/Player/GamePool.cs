using Microsoft.Extensions.ObjectPool;

namespace EXCell
{
    public class GamePool<T> : IGamePool<T> where T : class, new()
    {
        public ObjectPool<T> Pool { get; } = ObjectPool.Create<T>();

        public T Get()
        {
            return Pool.Get();
        }

        public void Return(T obj)
        {
            Pool.Return(obj);
        }
    }
}