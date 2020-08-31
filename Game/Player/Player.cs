using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace EXCell
{
    public partial class Player : IDoDamage<IDamageable>, IDamageable, IBaseEntity, ILevelable
    {

        public string Name { get; set; } = Console.ReadLine();

        public IHealth Health { get; } = new PlayerHealth();

        public IPlayerItems Items { get; set; } = new PlayerItems();

        public int CurrentXP { get; internal set; } = 0;
        public int Level { get; internal set; } = 1;
        public void GainExpierence(int XP)
        {
            CurrentXP += XP;
            if (CurrentXP == ILevelable.NextLevel)
            {
                CurrentXP = 0;
                Level += 1;
            }
        }

        public void TakeDamage(int amount)
        {
            Health.CurrentHealth -= amount;
        }

        public void DoDamage(IDamageable target)
        {
            target.TakeDamage(10);
        }
    }
}