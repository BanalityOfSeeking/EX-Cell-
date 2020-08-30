using System;

namespace EXCell
{
    public interface IDoDamage<T> where T : IDamageable
    {
        public static Range DamageRange = new Range(1, 10);

        public void DoDamage(T target);
    }
}