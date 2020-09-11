namespace Game.Components
{
    public interface ILevelableComponent
    {
        int CurrentXP { get; set; }
        int Level { get; set; }
    }
}