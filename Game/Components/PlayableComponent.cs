namespace Game.Components
{
    public class PlayableComponent : IComponentType
    {
        public bool Playable { get; set; }

        public ComponentTypes ComponentId => ComponentTypes.Playable;
    }
}