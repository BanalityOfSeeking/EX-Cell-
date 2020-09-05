namespace EXCell
{
    public struct HealthComponent : IHealthComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public HealthComponent(int parentId, int childId, int maxHealth, int currentHealth)
        {
            ParentId = parentId;
            ChildId = childId;
            MaxHealth = 0;
            CurrentHealth = 0;
        }
    }
}

