using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXCell
{
    public static class EquipmentRulesManager
    {
        // make it as immutable as possible (assuming that's what you want)

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

        private static IReadOnlyList<EquipId> Rules { get; set; }

        public static IEnumerable<EquipId> GetItemsOfType(this EquipId equip)
        {
            return Rules.Where(x => x.EquipmentType == equip.EquipmentType);
        }

        public static EquipId ApplyRule(this EquipId equip)
        {
  
            if (equip.Value == default)
            {
                IEnumerable<EquipId> items = GetItemsOfType(equip);
                if (items.Any())
                {
                    var item = items?.FirstOrDefault(x => x.Value == equip.Value + 1);
                    if(item.HasValue)
                    {
                        return item.Value;
                    }                    
                }
                return equip;
            }
            else
            {
                return GetItemsOfType(equip).FirstOrDefault(x => x.Value == equip.Value);
            }
        }
    }
}