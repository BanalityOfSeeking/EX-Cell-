using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EXCell
{
    public class Equipment : IEquipment
    {
        public IEquipId Id { get; internal set; }
        public Equipment()
        {
        }
        public IEquipId Progress(EquipmentRulesManager equipRuler)
        {
            return equipRuler.ApplyRule(Id);
        }
    }
}