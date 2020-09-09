namespace Game.Components
{
    public interface ILevelableComponent
    {
        ComponentTypes ComponentId { get; }
        byte CurrentXP { get; }
        byte Level { get; }
    }
}