using System;

namespace EXCell
{
    public enum EquipType
    {
        Helmets = 0,
        Armors,
        Weapons,
        LegGuards
    }

    public struct EquipId : IEquipId
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