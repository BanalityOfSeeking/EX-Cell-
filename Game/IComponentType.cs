using System.Collections.Generic;

namespace EXCell
{
    public interface IComponentType
    {
        public abstract List<ComponentType> ComponentComponents { get; }
        public bool NeedUpdate { get; }
        BaseEntity EntityId { get; }
        public Levelable? Level { get; }
        public HealthComponent Health { get; }
        public Items? Items { get; }
        public AttackEventHandler? AttackEvent { get; }
        public bool UpdateComponents();
        public DisplayUnit Unit { get; }
    }
}