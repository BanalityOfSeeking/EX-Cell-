namespace EXCell
{
    public static class AttackRegistrationHandler 
    {
        public static void AttackSetup(this ComponentType attacker, ComponentType defender)
        {
            var pa = attacker.AttackEvent ?? null;
            if (pa != null)
            {
                var ae = pa.Value;
                ae.Target = defender.Health;
                ae.DoDamageEvent += ae.DoDamage;
                attacker.AttackEvent = pa;
            }
        }
    }
}