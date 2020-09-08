
using System;
using System.Collections.Generic;

namespace Game.Entities
{
    public interface IEntityManager
    {
        EntityId? CreateEntityId();
        bool DestroyEntityId(int Id);
    }
    public class EntityManager : IEntityManager
    {
        private EntityId[] entities = new EntityId[32];
        private List<int> UsedEntities = new List<int>(32);
        public EntityManager()
        {
            int Id = 1;
            for (; Id < 32; Id++)
            {
                entities[0] = new EntityId(Id);
            }
        }
        public EntityId? CreateEntityId()
        {
            EntityId Id = new EntityId();
            int AvailableId = 1;
            do
            {
                if (!UsedEntities.Contains(AvailableId))
                {
                    UsedEntities.Add(AvailableId);
                    Id.Id = AvailableId;
                    return Id;
                }
                AvailableId++;
            } while (AvailableId < 32);
            return null;
        }
        public bool DestroyEntityId(int Id)
        {
            return UsedEntities.Remove(Id);
        }
    }
}