
using System.Data;

namespace Game.Components
{
    public struct HealthComponent : IHealthComponent, IComponentType
    {
        public int ComponentId { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}

