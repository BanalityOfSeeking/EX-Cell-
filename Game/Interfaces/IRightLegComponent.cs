namespace Game.Components
{
    public interface IRightLegComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char[] Item { get; set; }
    }
}