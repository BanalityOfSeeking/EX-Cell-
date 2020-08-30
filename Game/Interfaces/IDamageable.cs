namespace EXCell
{
    public interface IDamageable
    {
        public IHealth Health { get; }

        public void TakeDamage(int amount);
    }
}