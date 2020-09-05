namespace EXCell
{
    public interface IHealthComponent  : IComponentType//
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}

