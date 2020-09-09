namespace Game.Components
{
    public interface IRightArmComponent
    {
        ComponentTypes ComponentId { get; }
        EquipId Id { get; set; }
        char[] Item { get; set; }
    }
}