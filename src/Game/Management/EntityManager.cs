using System.Collections;

namespace Game
{
    public interface IEntityManager
    {
        int? CreateEntityId();
        void DestroyEntityId(int entityId);
        int Test { get; set; }
    }

    public class EntityManager : IEntityManager
    {
        public int Test { get; set; }
        private Hashtable UsedEntities = new Hashtable();

        public int? CreateEntityId()
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
        public void DestroyEntityId(int entityId)
        {
            UsedEntities.Remove(entityId);
        }
    }
}