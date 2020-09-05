namespace EXCell
{
    public static class AttackRegistrationHandler 
    {
        public static void AttackSetup(this ref ComponentType attacker)
        {
            var pa = attacker.AttackEvent ?? null;
            if (pa != null)
            {
                var ae = pa.Value;
                ae.DoDamageEvent += DoDamage;
                attacker.AttackEvent = ae;
            }
        }
        public static void DoDamage(HealthComponent sender, ref HealthComponent reciever)
        {
            reciever.CurrentHealth -= 10;
        }
    }
}