namespace Game.Components
{
    public class LeftArmComponent : IEquipment, Item, IComponentType, ILeftArmComponent
    {
        public EquipId Id { get; set; }

        public char[] Item { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.LeftArm;
    }
}