using Game.Components;

namespace Game.Systems
{
    public interface IDeath
    {
        public void Death(short id);
    }

    public class DeathSystem : IDeath
    {
        public DeathSystem()
        {
        }

        public void Death(short id)
        {
        }
    }
}

