namespace Game.Components
{
    public struct PlayableComponent : IPlayableComponent, IComponentType
    {
        public int ComponentId { get; set; }
        public bool Playable { get; set; }
    }
}