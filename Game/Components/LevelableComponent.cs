namespace Game.Components
{
    public class LevelableComponent : IComponentType
    {
        public byte CurrentXP { get; internal set; }
        public byte Level { get; internal set; }

        public ComponentTypes ComponentId => ComponentTypes.Levelable;
    }
}