using Game.Components;

namespace Game.Systems
{
    public interface IDeath
    {
        public void Death(int Id);
    }

    public static class DeathSystem
    {
        public static void Death(int Id)
        {
            EntityManager.DestroyEntityId(Id);
        }
    }
}

