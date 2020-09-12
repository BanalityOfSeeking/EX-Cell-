namespace Game.Components
{
    public struct LevelableComponent : ILevelableComponent, IComponentType
    {
        public int ComponentId { get; set; }
        public int CurrentXP { get; set; }
        public int Level { get; set; }

    }
}