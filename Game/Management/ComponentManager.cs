using Game.Entities;
using Game.Components;
using System.Collections.Generic;

namespace Game.Manager
{

    public class ComponentManager
    {
        public void RequestComponent<T>(EntityId entityId) where T : IComponentType, new()
        {
            if(EntityMappings.TryGetValue(entityId, out IList<IComponentType> componentList))
            {
                componentList.Add(new T());
            }
            else
            {
                var MappingList = new List<IComponentType>();
                MappingList.Add(new T());
                EntityMappings.Add(entityId, MappingList);
            }
        }
        public bool DestroyEntityComponents(EntityId entityId)
        {
            if (EntityMappings.ContainsKey(entityId))
            {
                EntityMappings.Remove(entityId);
                return true;
            }
            return false;
        }
        public Dictionary<EntityId, IList<IComponentType>> EntityMappings { get; }

        public ComponentManager()
        {
            EntityMappings = new Dictionary<EntityId, IList<IComponentType>>();
        }
    }
}
