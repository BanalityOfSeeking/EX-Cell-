using Game.Components;

using System;
using System.Collections.Generic;

namespace Game.Systems
{
    public class EquipmentSystem
    {

        internal static readonly IReadOnlyList<EquipId> ProgressionList = new List<EquipId>()
        {
                //head
            new EquipId(0, 0, EquipType.Helmets),
            new EquipId( 1, 1, EquipType.Helmets),
            new EquipId(2, 2, EquipType.Helmets),
            new EquipId(3, 3, EquipType.Helmets),
                //chest
            new EquipId(0, 0, EquipType.Armors),
            new EquipId(1, 0, EquipType.Armors),
            new EquipId(2, 1, EquipType.Armors),
            new EquipId(3, 2, EquipType.Armors),
                //arms
            new EquipId(0, 0, EquipType.Weapons),
            new EquipId(1, 2, EquipType.Weapons),
            new EquipId(2, 3, EquipType.Weapons),
            new EquipId(3, 5, EquipType.Weapons),
                //legs
            new EquipId(0, 0, EquipType.LegGuards),
            new EquipId(1, 2, EquipType.LegGuards)
        };

        private static IReadOnlyList<EquipId> Rules { get => ProgressionList; }

        public IEnumerable<EquipId> GetItemsOfType(EquipId equip)
        {
            foreach(var li in Rules)
            {
                yield return li;
            }
        }

        public EquipId RuleUpdater(EquipId equip)
        {
            IEnumerable<EquipId> items = GetItemsOfType(equip);
            foreach(var item in items)
            {
                if (item.Value == equip.Value + 1)
                {
                    return item;
                }
            }
            return equip;

        }
    }
}