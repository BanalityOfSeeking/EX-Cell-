using Game.Components;
using Game.Entities;
using System;
using System.Collections.Generic;

namespace Game.Systems.Stages
{

    public class StageHost : IStageHost
    {
        public EntityRoles[] RequiredRoles { get; set; } = new EntityRoles[2];
        public Dictionary<EntityId, IComponentType[]> EntityComponents { get; set; }
        public StageHost(EntityRoles[] requiredRoles = null)
        {
            if(requiredRoles != null)
            {
                RequiredRoles = requiredRoles;
            }
            EntityComponents = new Dictionary<EntityId, IComponentType[]>();
            RequiredRoles[0] = EntityRoles.PLAYER;
            RequiredRoles[1] = EntityRoles.MONSTER;
        }

        public virtual void AddEntity(EntityId Id, IComponentType[] requiredComponent)
        {

            EntityComponents.Add(Id, requiredComponent);
        }
    }
}
