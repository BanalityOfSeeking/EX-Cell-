namespace EXCell
{
    public struct PlayableComponent : IPlayable
    {
        public bool Playable => true;
        public int ParentId { get; set; }
        public int ChildId { get; set; }
    }
}