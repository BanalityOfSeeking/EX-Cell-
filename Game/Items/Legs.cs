using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EXCell
{
    public class Legs : IEquipment, ItemLeftRight
    {

        public ImmutableList<char> Input { get; set; } = @"/\".ToImmutableList();

        public EquipId Id {get; set;}

        public char Left() => Input[0];
        public char Right() => Input[1];

        public Legs()
        {
            Id = new EquipId(0, 0, EquipType.LegGuards);
            Id = EquipmentRulesManager.ApplyRule(Id);
        }
    }
}