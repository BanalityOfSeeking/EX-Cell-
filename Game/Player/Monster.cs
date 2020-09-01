using System;
using System.Collections.Generic;

namespace EXCell
{
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

        public bool HasTreasure { get; set; } = true;

        public int TreasureCode { get; set; } = 1;

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