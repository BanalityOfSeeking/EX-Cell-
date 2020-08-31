using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;

namespace EXCell
{
    public interface IGamePool<T> where T : class, new()
    {
        public ObjectPool<T> Pool { get; }

        public T Get();

        public void Return(T obj);
    }

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

    public interface IPoolGameObject
    {
        IGamePool<Player> PlayerPool { get; } 
        IGamePool<Monster> MonstePool { get; }
    }
    public class GamePools : IPoolGameObject
    {
        public IGamePool<Player> PlayerPool { get; } = new GamePool<Player>();

        public IGamePool<Monster> MonstePool { get; } = new GamePool<Monster>();
    }

    public class Monster : IDoDamage<IDamageable>, IDamageable, IBaseEntity, IDisplay, ICarry, IDrop
    {
        public IHealth Health { get; } = new MonsterHealth<HealthProgression>();
        public int XP { get; } = 10;

        public string Name { get; } = "Monster";

        public List<string> Unit = new List<string>()
                {
                    @"  /o|o\"  ,
                    @" \| = |/  ",
                    @"  | | |  ",
                };

        public bool HasTreasure { get; set; }

        public int TreasureCode { get; set; }

        List<string> IDisplay.Unit => throw new NotImplementedException();

        public int X => 15;

        public int Y => 7;

        public void DoDamage(IDamageable target)
        {
            target.TakeDamage(10);
        }

        public void TakeDamage(int amount)
        {
            Health.CurrentHealth -= amount;
        }
    }
}