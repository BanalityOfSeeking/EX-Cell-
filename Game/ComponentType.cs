using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EXCell
{
    public struct ComponentType : IComponentType
    {
        public ComponentType([NotNull] string name, bool gainXp, int maxHealth = 1, bool hasItems = false, bool canAttack = false)
        {
            EntityId = new BaseEntity(name);
            if (gainXp)
            {
                Level = new Levelable();
            }
            else
            {
                Level = null;
            }
            Health = new HealthComponent(maxHealth, maxHealth);
            if (hasItems)
            {
                Items = new Items();
            }
            else
            {
                Items = null;
            }
            if (canAttack)
            {
                AttackEvent = new AttackEventHandler();
            }
            else
            {
                AttackEvent = null;
            }
            NeedUpdate = true;
            ComponentComponents = null;
            Unit = new DisplayUnit()
            {
                Unit = new List<string>()
                {
                    @"  /o|o\"  ,
                    @" \| = |/  ",
                    @"  | | |  ",
                }
            };
        }
        public BaseEntity EntityId { get; }
        public Levelable? Level { get; }
        public HealthComponent Health { get; }//set; } = new HealthComponent(100,100);
        public Items? Items { get; }//set; } = new PlayerItems();
        public AttackEventHandler? AttackEvent { get; set; }

        public bool NeedUpdate { get; set; }

        public List<ComponentType> ComponentComponents { get; internal set; }

        public DisplayUnit Unit { get; set; }

        public bool UpdateComponents()
        {
            NeedUpdate = false;
            return true;
        }
    }
}