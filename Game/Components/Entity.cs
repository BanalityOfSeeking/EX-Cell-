using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;


namespace Game.Entities
{

    public struct EntityId //: IGame
    {
        public EntityId(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        
    }
}