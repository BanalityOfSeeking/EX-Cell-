namespace Game.Components
{
    public class RightLegComponent : IEquipment, Item, IComponentType
    {
        public char Item { get; set; }
        public EquipId Id { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.RightLeg;
    }
}