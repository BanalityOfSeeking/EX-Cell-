namespace EXCell
{
    public interface IEquipId : IBaseEntity
    {
        int Value { get; }
        int Enchantment { get; }
        EquipType EquipmentType { get; }
    }
}