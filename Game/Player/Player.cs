using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Policy;

namespace EXCell
{
    public struct BaseEntity : IBaseEntity
    {
        public BaseEntity(string name, Guid gameId = new Guid())
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            GameId = gameId;
        }

        public string Name { get; }

        public Guid GameId { get; }
    }

    public struct Levelable : ILevelable
    {
        public int CurrentXP { get; set; }

        public int Level { get; set; }

        public void GainExpierence(int XP)
        {
            CurrentXP += XP;
            if (CurrentXP == ILevelable.NextLevel)
            {
                CurrentXP = 0;
                Level += 1;
            }
        }
    }

    //public struct Playable
    //{
    //    public BaseEntity EntityId { get; }
    //    public Levelable Level { get; }
    //    public HealthComponent Health { get; }//set; } = new HealthComponent(100,100);

    //    public Items Items { get; }//set; } = new PlayerItems();

    //    public AttackEventHandler AttackEvent { get; }
    //}
}