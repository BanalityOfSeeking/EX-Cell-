
using System.Data;

namespace Game.Components
{
    public struct HealthComponent : IHealthComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}

