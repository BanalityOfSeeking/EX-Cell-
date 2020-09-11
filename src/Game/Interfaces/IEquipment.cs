namespace Game.Components
{
    public interface IEquipment
    {
        public int Value { get; }
        public int Enchantment { get; }

    }
    public interface IEquipType
    {
        public EquipTypes EquipType { get; }
    }
}