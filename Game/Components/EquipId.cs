
using System;

namespace Game.Components
{
    public enum EquipType
    {
        Helmets = 0,
        Armors = 1,
        Weapons = 2,
        LegGuards = 3
    }

    public class EquipId : IEquipId
    {
        public EquipId(int value, int enchantment, EquipType equip)
        {
            
            Value = value;
            Enchantment = enchantment;
            EquipmentType = equip;
        }

        public int Value { get; }
        public int Enchantment { get; }
        public EquipType EquipmentType { get; }

    }
}