using Game.Components;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Systems
{
    public class EquipmentSystem
    {
        /*
        private IReadOnlyList<(EntityRoles, PartComponent)> ProgressionList = new List<(EntityRoles, PartComponent)>()
        {
            // Default Head.
            (EntityRoles.Player, new PartComponent(0, 0, new char[] {'0'})),

            (EntityRoles.Player, new PartComponent(1, 0, new char[] {'o'})),
            (EntityRoles.Player, new PartComponent(2, 1, new char[] {'O'})),
            (EntityRoles.Player, new PartComponent(3, 1, new char[] {'u'})),
            (EntityRoles.Player, new PartComponent(4, 2, new char[] {'U'})),
            
            // Default Left Arm
            (EntityRoles.Player, new PartComponent(0, 0, new char[] {'/'})),

            (EntityRoles.Player, new PartComponent(1, 0, new char[] {'/', '('})),
            (EntityRoles.Player, new PartComponent(2, 0, new char[] {'<', '('})),
            (EntityRoles.Player, new PartComponent(3, 0, new char[] {'/', '<'})),
            (EntityRoles.Player, new PartComponent(4, 0, new char[] {'(', '('})), 

            // Default RIght Arm
            (EntityRoles.Player, new PartComponent(0, 0, new char[] {'\\'})),

            (EntityRoles.Player, new PartComponent(1, 0, new char[] {'\\', ')'})),
            (EntityRoles.Player, new PartComponent(2, 0, new char[] {'>', ')'})),
            (EntityRoles.Player, new PartComponent(3, 0, new char[] {'\\', '>'})),
            (EntityRoles.Player, new PartComponent(4, 0, new char[] {')', ')'}))
        };

        private IReadOnlyList<(EntityRoles Role, PartComponent Component)> Rules { get => ProgressionList; }

        public IEnumerable<PartComponent> GetItemsForRole(EntityRoles role)
        {
            foreach(var rule in Rules)
            {
                if(rule.Role == role)
                {
                    yield return rule.Component;
                }
            }
        }

        public PartComponent ApplyRule(PartComponent bodyPart)
        {
            return new PartComponent();
        }
    }
        */
    }
}