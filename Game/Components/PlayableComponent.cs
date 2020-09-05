namespace EXCell
{
    public struct PlayableComponent : IPlayable
    {
        public bool Playable => true;
        public int ParentId { get; set; }
    }
}