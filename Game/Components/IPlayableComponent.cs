namespace Game.Components
{
    public interface IPlayableComponent
    {
        ComponentTypes ComponentId { get; }
        bool Playable { get; set; }
    }
}