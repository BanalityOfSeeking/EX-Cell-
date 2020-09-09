namespace Game.Components
{
    public interface IChestComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char[] Item { get; set; }
    }
}