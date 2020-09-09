namespace Game.Components
{
    public class RightLegComponent : IEquipment, Item, IComponentType, IRightLegComponent
    {
        public char[] Item { get; set; }
        public EquipId Id { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.RightLeg;
    }
}