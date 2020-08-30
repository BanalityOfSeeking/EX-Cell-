using System.Collections.Generic;

namespace EXCell
{
    public interface IEquipmentRulesManager
    {
        IEquipId ApplyRule(IEquipId item);

        IEnumerable<IEquipId> GetItemsOfType(EquipType itemType);
    }
}