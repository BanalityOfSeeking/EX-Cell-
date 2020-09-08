
namespace Game.Components
{
    public class HealthComponent : IHealthComponent, IComponentType
    { 

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Health;
    }
}

