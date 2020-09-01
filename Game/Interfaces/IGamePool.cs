using Microsoft.Extensions.ObjectPool;

namespace EXCell
{
    public interface IGamePool<T> where T : class, new()
    {
        public ObjectPool<T> Pool { get; }

        public T Get();

        public void Return(T obj);
    }
}