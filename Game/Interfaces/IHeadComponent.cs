namespace Game.Components
{
    public interface IHeadComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char Item { get; set; }
    }
}