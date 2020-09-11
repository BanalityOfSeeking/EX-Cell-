using Game.Components;

namespace Game.Systems
{
    public interface IDeath
    {
        public void Death(int Id);
    }

    public class DeathSystem : IDeath
    {
        private IEntityManager RequestEntity { get; } 
        public DeathSystem(IEntityManager manager)
        {
            RequestEntity = manager;
        }
        public void Death(int Id)
        {
            RequestEntity .DestroyEntityId(Id);
        }
    }
}

