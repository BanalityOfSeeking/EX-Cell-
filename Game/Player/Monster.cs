using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;

namespace EXCell
{
    public interface IGamePools<T, S> where T : class, new() where S : class, new()
    {
        public ObjectPool<T> Players { get; }
        public ObjectPool<S> Monsters { get; }

        public T Get();

        public void Return(T obj);

        public void Get(out S obj);

        public void Return(S obj);
    }

    public class GamePools : IGamePools<Player, Monster>
    {
        public ObjectPool<Player> Players { get; }

        public ObjectPool<Monster> Monsters { get; }

        public GamePools()
        {
            Players = ObjectPool.Create<Player>();
            Monsters = ObjectPool.Create<Monster>();
        }

        public Player Get()
        {
            return Players.Get();
        }

        public void Return(Player obj)
        {
            Players.Return(obj);
        }

        public void Get(out Monster obj)
        {
            obj = Monsters.Get();
        }

        public void Return(Monster obj)
        {
            Monsters.Return(obj);
        }
    }

    public class Monster : IDoDamage<Player>, IDamageable, IBaseEntity, IDisplayUnit, ICarry, IDrop
    {
        public IHealth Health { get; } = new MonsterHealth<HealthProgression>();
        public int XP { get; } = 10;

        public string Name { get; } = "Monster";

        public string DisplayUnit { get; }

        public List<string> Unit2 = new List<string>()
                {
                    @"-------/o|o\ --",
                    @"      \| = |/  ",
                    @"       | | |   ",
                };

        public void Display2ndUnit()
        {
            int i = 0;
            Console.SetCursorPosition(Left, Top);
            foreach (string d in Unit2)
            {
                i++;
                Console.WriteLine(d);
                Console.SetCursorPosition(Left, Top + i);
            }
        }

        public bool HasTreasure { get; set; }

        public int TreasureCode { get; set; }

        public int Top { get; set; } = 7;

        public int Left { get; set; } = 15;

        public void DoDamage(Player target)
        {
            target.TakeDamage(10);
        }

        public void TakeDamage(int amount)
        {
            Health.CurrentHealth -= amount;
            Health.Status = Health.GetHealthDescriptor(Health.CurrentHealth);
        }
    }
}