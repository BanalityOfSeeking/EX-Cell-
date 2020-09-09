namespace Game.Components
{
    public interface ILevelableComponent
    {
        ComponentTypes ComponentId { get; }
        int CurrentXP { get; }
        int Level { get; }
    }
}