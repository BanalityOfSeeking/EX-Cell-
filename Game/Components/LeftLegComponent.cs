namespace Game.Components
{
    public class LeftLegComponent : IEquipment, Item, IComponentType
    {
        public char Item { get; set; }
        public EquipId Id {get; set;}

        public ComponentTypes ComponentId => ComponentTypes.LeftLeg;
    }
}