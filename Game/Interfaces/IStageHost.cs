using Game.Components;
using Game.Entities;
using System.Collections.Generic;

namespace Game.Stages
{
    public interface IStageHost
    {
        Dictionary<EntityId, IComponentType[]> EntityComponents { get; }
        EntityRoles[] RequiredRoles { get; set; }

        void AddEntity(EntityId Id, IComponentType[] requiredComponents);
    }
}