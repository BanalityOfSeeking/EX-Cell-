namespace Game.Components
{
    public interface ILeftArmComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char Item { get; set; }
    }
}