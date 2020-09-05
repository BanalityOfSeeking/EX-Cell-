namespace EXCell
{
    public struct HealthComponent : IHealthComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int ParentId { get; set; }

        public HealthComponent(int parentId, int maxHealth, int currentHealth)
        {
            ParentId = parentId;
            MaxHealth = 0;
            CurrentHealth = 0;
        }
    }
}

