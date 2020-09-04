using System.Collections.Generic;
using System.Linq;

namespace EXCell
{
    public static class EquipmentRulesManager
    {
        // make it as immutable as possible (assuming that's what you want)

        internal static readonly IReadOnlyList<EquipId> ProgressionList = new List<EquipId>()
        {
                //head
            new EquipId("Party Hat", 0, 0, EquipType.Helmets),
            new EquipId("Helmet head", 1, 1, EquipType.Helmets),
            new EquipId("Iron FaceMask", 2, 2, EquipType.Helmets),
            new EquipId("ForceField", 3, 3, EquipType.Helmets),
                //chest
            new EquipId("Vest", 0, 0, EquipType.Armors),
            new EquipId("Leather Armor", 1, 0, EquipType.Armors),
            new EquipId("Plate Armor", 2, 1, EquipType.Armors),
            new EquipId("Chain Mail", 3, 2, EquipType.Armors),
                //arms
            new EquipId("Bare Hands", 0, 0, EquipType.Weapons),
            new EquipId("Sword & Shield", 1, 2, EquipType.Weapons),
            new EquipId("Long Sword", 2, 3, EquipType.Weapons),
            new EquipId("Flaming Sword", 3, 5, EquipType.Weapons),
                //legs
            new EquipId("Shorts", 0, 0, EquipType.LegGuards),
            new EquipId("Pads", 1, 2, EquipType.LegGuards)
        };

        private static IReadOnlyList<IEquipId> Rules { get; set; }

        private static IEnumerable<IEquipId> GetItemsOfType(this IEquipment equip)
        {
            if (Rules != default)
            {
                return Rules.Where(x => x.EquipmentType == equip.Id.EquipmentType);
            }
            else
            {
                Rules = ProgressionList;
                return Rules.Where(x => x.EquipmentType == equip.Id.EquipmentType);
            }
        }

        public static IEquipId ApplyRule(this IEquipment equip)
        {
            IEquipId Id;
            if (equip.Id.Name != string.Empty)
            {
                Id = GetItemsOfType(equip).FirstOrDefault(x => x.Value == equip.Id.Value + 1);
                if (Id == default)
                {
                    Id = GetItemsOfType(equip).FirstOrDefault(x => x.Value == equip.Id.Value);
                }
            }
            else
            {
                Id = GetItemsOfType(equip).FirstOrDefault(x => x.Value == equip.Id.Value);
            }
            return Id;
        }
        public static void LoadEquipmentProgressionList(IReadOnlyList<EquipId> equipRules = default)
        {
            if (equipRules == default)
            {
                Rules = equipRules;
            }
            else
            {
                Rules = ProgressionList;
            }
        }
    }
}