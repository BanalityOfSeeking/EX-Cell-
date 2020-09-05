namespace EXCell
{
    public interface IHealthComponent //
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Status { get; set; }
    }
}

