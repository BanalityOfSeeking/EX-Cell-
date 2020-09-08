namespace Game.Components
{
    public class ChestComponent : IEquipment, Item, IComponentType
    {
        public EquipId Id { get; set; }
        public char Item { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Chest;
    }
}