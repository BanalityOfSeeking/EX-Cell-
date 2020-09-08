namespace Game.Components
{
    public interface IEquipId
    {
        int Value { get; }
        int Enchantment { get; }
        EquipType EquipmentType { get; }
    }
    
}