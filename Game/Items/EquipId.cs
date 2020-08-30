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

    public class EquipId : IEquipId
    {
        public EquipId(string name, int value, int enchantment, EquipType equip)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
            Enchantment = enchantment;
            EquipmentType = equip;
        }

        public string Name { get; }
        public int Value { get; }
        public int Enchantment { get; }
        public EquipType EquipmentType { get; }
    }
}