using System.Data;

namespace EXCell
{
    public interface IEquipment
    {
        IEquipId Id { get; }
        IEquipId Progress(EquipmentRulesManager equipRuler);
    }
}
