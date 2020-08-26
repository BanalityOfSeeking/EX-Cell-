using System;

namespace EXCell
{
    public class Monster : IMonster
    {
        public Monster(string name, int health, Random gameRoller)
        {
            Name = name;
            IsAlive = true;
            Health = health;
            HasTreasure = gameRoller.Next(10, 99) > 50 ? true : false;
            TreasureCode = HasTreasure ? gameRoller.Next(1,4) : 0;
        }

        public string Name { get; }
        public int Health { get; }
        public bool IsAlive { get; }
        public bool HasTreasure { get; }
        public int TreasureCode { get; }
    }
}