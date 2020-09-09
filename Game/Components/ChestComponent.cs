namespace Game.Components
{
    public class ChestComponent : IEquipment, Item, IComponentType, IChestComponent
    {
        public EquipId Id { get; set; }
        public char Item { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Chest;
    }
}