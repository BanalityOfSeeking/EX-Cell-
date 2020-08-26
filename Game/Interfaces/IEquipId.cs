namespace EXCell
{
    public interface IEquipId
    {
        string Name { get; }
        int Value { get; }
        int Enchantment { get; }
        EquipType EquipmentType { get; }
    }

}