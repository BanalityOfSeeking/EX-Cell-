namespace Game.Components
{
    public class PlayableComponent : IComponentType, IPlayableComponent
    {
        public bool Playable { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Playable;
    }
}