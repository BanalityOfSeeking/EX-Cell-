﻿namespace Game.Components
{
    public class CarryTreasureComponent : ICarryTreasure, IComponentType
    {
        public byte Treasure { get; set; }
        public EquipType Equip { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Carry;
    }
}