namespace Game.Components
{
    public class LevelableComponent : IComponentType, ILevelableComponent
    {
        public byte CurrentXP { get; internal set; }
        public byte Level { get; internal set; }

        public ComponentTypes ComponentId => ComponentTypes.Levelable;
    }
}