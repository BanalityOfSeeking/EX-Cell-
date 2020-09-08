using System;

using Game.Components;
using Game.Entities;

namespace Game
{
    public class AttackSystem
    {
        public ComponentManager Manager = new ComponentManager();
        public static Random AttackRandom = new Random();
        private EntityId Entity1 { get; }
        private EntityId Entity2 { get; }

        public static byte Entity1Damage = 10;// Entity 1 Damage
        public static byte Entity2Damage = 10;  // Entity 2 Defense
        public int Roll1 => AttackRandom.Next(0, 99);
        public int Roll2 => AttackRandom.Next(0, 99);
        public int Modifier1 => -AttackRandom.Next(0, 9);
        public int Modifier2 => -AttackRandom.Next(0, 9);
        public EntityId EntityId { get; set; }
        public void AttackProduce()
        {
            if((Roll1 + Modifier1) > (Roll2 + Modifier2))
            {
                //Manager
                //hub.Publish((Entity1.Id,
            }

            //hub.Publish((Entity1.Id, );
        }
    }
}

