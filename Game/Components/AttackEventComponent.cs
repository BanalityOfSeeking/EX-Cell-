using System;
using Game.Components;


namespace Game
{
    public class AttackSystem
    {
        public static Random AttackRandom = new Random();
        private int Entity1 { get; }
        private int Entity2 { get; }

        public static byte Entity1Damage = 10;// Entity 1 Damage
        public static byte Entity2Damage = 10;  // Entity 2 Defense
        public int Roll1 => AttackRandom.Next(0, 99);
        public int Roll2 => AttackRandom.Next(0, 99);
        public int Modifier1 => -AttackRandom.Next(0, 9);
        public int Modifier2 => -AttackRandom.Next(0, 9);
        public int EntityId { get; set; }
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

