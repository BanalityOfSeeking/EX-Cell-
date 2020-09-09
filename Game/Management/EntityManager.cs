
using Game.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Manager.Entities
{
    public interface IEntityManager
    {
        EntityId? CreateEntityId();
        void DestroyEntityId(EntityId entityId);
    }

    public class EntityManager : IEntityManager
    {
        private Hashtable UsedEntities = new Hashtable();
        public EntityManager()
        {
        }
        public EntityId? CreateEntityId()
        {
           
            int AvailableId = 1;
            do
            {
                if (!UsedEntities.Contains(AvailableId))
                { 
                    UsedEntities.Add(AvailableId, AvailableId);
                    return new EntityId(AvailableId);
                }
                AvailableId++;
            } while (AvailableId < 64);
            return null;
        }
        public void DestroyEntityId(EntityId entityId)
        {
            UsedEntities.Remove(entityId.Id);
        }
    }
}