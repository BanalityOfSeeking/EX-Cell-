namespace Game.Components
{
    public struct CarryTreasureComponent : ICarryTreasure
    {
        public byte Treasure { get; set; }
        public EquipTypes Equip { get; set; }

    }
}