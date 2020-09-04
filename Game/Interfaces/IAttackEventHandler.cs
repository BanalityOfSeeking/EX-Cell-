using System;

namespace EXCell
{
    public interface IDamageable
    {
        public HealthComponent Health { get; }
    }

    public interface IAttackEventHandler
    {
        public HealthComponent Target { get; }

        public event EventHandler DoDamageEvent;

        public void OnDamageEvent(EventArgs e);
        public void DoDamage(object sender, EventArgs e);
    }

    public struct AttackEventHandler : IAttackEventHandler
    {
        public HealthComponent Target { get; set; }

        public event EventHandler DoDamageEvent;

        public void OnDamageEvent(EventArgs e)
        {

            EventHandler handler = DoDamageEvent;
            if (handler != null)
            {
                handler(Target, e);
            }
        }
        public void DoDamage(object sender, EventArgs e)
        {
            Target = new HealthComponent(((IHealthComponent)sender).MaxHealth, ((IHealthComponent)sender).CurrentHealth - 10);
        }
    }
    public interface IHealthComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Status { get; set; }
        public void Update(HealthComponent HealthAdjust);
    }

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
        public void Update(HealthComponent HealthAdjust)
        {
            MaxHealth = HealthAdjust.MaxHealth;
            CurrentHealth = HealthAdjust.CurrentHealth;
            Status = Status != HealthAdjust.Status ? HealthAdjust.Status : Status;
        }
    }

}

