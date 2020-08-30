using System.Collections.Generic;
using System.Linq;

namespace EXCell
{
    public class EquipmentRulesManager : AbstractRulesManager<IEquipId, EquipType>, IEquipmentRulesManager
    {
        // make it as immutable as possible (assuming that's what you want)

        public EquipmentRulesManager()
        {
            Rules = ProgressionList;
        }

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

        public override IEnumerable<IEquipId> GetItemsOfType(EquipType itemType)
        {
            return Rules.Where(x => x.EquipmentType == itemType);
        }

        public override IEquipId ApplyRule(IEquipId item)
        {
            IEquipId Id;
            if (item.Name != string.Empty)
            {
                Id = GetItemsOfType(item.EquipmentType).FirstOrDefault(x => x.Value == item.Value + 1);
                if (Id == default)
                {
                    Id = GetItemsOfType(item.EquipmentType).FirstOrDefault(x => x.Value == item.Value);
                }
            }
            else
            {
                Id = GetItemsOfType(item.EquipmentType).FirstOrDefault(x => x.Value == item.Value);
            }
            return Id;
        }
    }

    public static class EquipementRulesManagerExtensions
    {
        public static void LoadEquipmentProgressionList(this EquipmentRulesManager manager, IReadOnlyList<EquipId> equipRules)
        {
            manager.Rules = equipRules;
        }
    }
}