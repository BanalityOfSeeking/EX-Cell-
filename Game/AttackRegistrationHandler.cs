namespace EXCell
{
    public static class AttackRegistrationHandler 
    {
        public static void AttackSetup(this ref AttackEventComponent attacker)
        {
           attacker.DoDamageEvent += DoDamage;       
        }
        public static void DoDamage(ref AttackEventComponent sender, ref HealthComponent reciever)
        {
            reciever.CurrentHealth -= 10;
        }
    }
}