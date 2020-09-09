namespace Game.Components
{
    public class LevelableComponent : IComponentType, ILevelableComponent
    {
        public int CurrentXP { get; internal set; }
        public int Level { get; internal set; }

        public ComponentTypes ComponentId => ComponentTypes.Levelable;
    }
}