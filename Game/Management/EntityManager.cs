
using System.Collections;

namespace Game
{
    public interface IEntityManager
    {
        int? CreateEntityId();
        void DestroyEntityId(int entityId);
    }

    public static class EntityManager
    {
        private static Hashtable UsedEntities = new Hashtable();

        public static int? CreateEntityId()
        {
           
            int AvailableId = 1;
            do
            {
                if (!UsedEntities.Contains(AvailableId))
                { 
                    UsedEntities.Add(AvailableId, AvailableId);
                    return AvailableId;
                }
                AvailableId++;
            } while (AvailableId < 64);
            return null;
        }
        public static void DestroyEntityId(int entityId)
        {
            UsedEntities.Remove(entityId);
        }
    }
}