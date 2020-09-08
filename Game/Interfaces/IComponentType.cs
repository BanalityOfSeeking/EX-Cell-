namespace Game.Components
{
    public enum ComponentTypes
    {
        Stats = 0,
        Head,
        Chest,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Carry,
        Display,
        Health,
        Attack,
        Playable,
        Levelable
    };

    public interface IComponentType
    { 
        ComponentTypes ComponentId { get; }
    }
}
