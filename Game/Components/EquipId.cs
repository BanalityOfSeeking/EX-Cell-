
using System;

namespace Game.Components
{
    public enum EquipType
    {
        Default = 0,
        Helmets = 1,
        Armors = 2,
        Weapons = 3,
        LegGuards = 4
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