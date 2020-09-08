using Game.Components;
using Game.Entities;

namespace Game.Systems.Death
{
    public interface IDeath
    {
        public EntityManager EntityManager { get; }
        public void Death(int Id);
    }

    public class DeathSystem : IDeath
    {
        public EntityManager EntityManager { get; }

        public DeathSystem(EntityManager entityManager, ComponentManager componentManager)
        {
            EntityManager = entityManager;

        }
        public void Death(int Id)
        {
            EntityManager.DestroyEntityId(Id);
        }
    }
}

