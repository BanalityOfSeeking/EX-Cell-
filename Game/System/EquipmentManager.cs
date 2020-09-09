using Game.Components;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Systems
{
    public static class EquipmentSystem
    {

        private static readonly IReadOnlyList<EquipId> ProgressionList = new List<EquipId>()
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

        public static IEnumerable<EquipId> GetItemsOfType(EquipId equip)
        {
            return from rule in Rules
                   where rule.EquipmentType.Equals(equip.EquipmentType)
                   select rule;
        }

        public static EquipId ApplyRule(EquipId equip, EquipType equipType)
        {
            IEnumerable<EquipId> items;
            var Item = new EquipId(-1, -1, equipType);
            if (equipType == EquipType.Default)
            {
                items = GetItemsOfType(equip);
            }
            else 
            {
                
                items = GetItemsOfType(Item);
            }
            foreach (var item in items)
            {
                if (item.Value == Item.Value + 1)
                {
                    return item;
                }
            }
            return equip;

        }
    }
}