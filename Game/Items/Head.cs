using System;
using System.Reflection.Metadata.Ecma335;

namespace EXCell
{
    public class Head : IEquipment, Item
    {
        public IEquipId Id { get; set; }

        public char Item => '0';

        public Head()
        {
            Id = new EquipId("", 0, 0, EquipType.Helmets);
            Id = EquipmentRulesManager.ApplyRule(this);
        }
    }
}