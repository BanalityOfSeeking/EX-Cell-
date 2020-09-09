namespace Game.Components
{
    public interface ILeftLegComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char Item { get; set; }
    }
}