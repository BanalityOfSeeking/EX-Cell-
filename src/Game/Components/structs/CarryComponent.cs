namespace Game.Components
{
    public struct CarryTreasureComponent : ICarryTreasure, IComponentType
    {
        public int ComponentId { get; set; }
        public byte Treasure { get; set; }
        public EquipTypes Equip { get; set; }

    }
}