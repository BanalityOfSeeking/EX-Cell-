using System;

namespace Game.Components
{
    public class RightArmComponent : IEquipment, Item, IComponentType, IRightArmComponent
    {
        public EquipId Id { get; set; }

        public char[] Item { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.RightArm;
    }
}