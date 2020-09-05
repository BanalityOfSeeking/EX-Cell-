using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;


namespace EXCell
{

    public ref struct Entity //: IGame
    {
        private static int GameIdBase = 0;
        private static int Increment = 1;
        private static int PrevGameId = -10;

        public List<EntityType> Entities { get; set; }
        internal int GenerateGameId()
        {
            if(PrevGameId < 0)
            {
                return PrevGameId = GameIdBase + Increment;
            }
            else
            {
                return PrevGameId = PrevGameId + Increment;
            }
        }
        public EntityType CreateEntityType()
        {
            var et = new EntityType(GenerateGameId(), null);
            if (Entities == default)
            {
                Entities = new List<EntityType>();
            }
            Entities.Add(et);
            return et;
        }
    }
}