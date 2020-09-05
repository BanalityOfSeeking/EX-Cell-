namespace EXCell
{
    public struct HealthComponent : IHealthComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Status { get; set; }

        public HealthComponent(int maxHealth, int currentHealth, string status = "unused")
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Status = status;
        }
    }
}

