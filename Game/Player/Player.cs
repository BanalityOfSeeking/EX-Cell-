namespace EXCell
{
    public class Player : IDoDamage<Monster>, IDamageable, IBaseEntity, IDisplayUnit, ILevelable
    {
        public string Name { get; set; } = "Player1";

        public IHealth Health { get; } = new PlayerHealth<HealthProgression>();

        private static string BaseUnit =>
                @"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/" +
                @"                              " + "\n" +
                @"                              " + "\n" +
                @"                              " + "\n" +
                @"                              " + "\n" +
                @"                              " + "\n" +
                @"                              " + "\n" +
                @"    {3}                       " + "\n" +
                @"--------{4}-----              " + "\n" +
                @"       {5}{6}{7}              " + "\n" +
                @"  | | ({8}_{9})               " + "\n" +
                @"==============================" + "\n" +
                @"|=============================" + "\n" +
                @"| Health:{0} XP:{1}               " + "\n" +
                @"| Level {2}                     " + "\n" +
                @"|=============================";

        public string DisplayUnit
        { get; set; } = BaseUnit;

        public int CurrentXP { get; internal set; }
        public int Level { get; internal set; }

        public int Top => 0;

        public int Left => 0;

        public void DoDamage(Monster target)
        {
            target.TakeDamage(10);
        }

        public void GainExpierence(int XP)
        {
            CurrentXP += XP;
            if (CurrentXP == ILevelable.NextLevel)
            {
                CurrentXP = 0;
                Level += 1;
            }
        }

        public void TakeDamage(int amount)
        {
            Health.CurrentHealth -= amount;
            Health.GetHealthDescriptor(Health.CurrentHealth);
        }

        public void Display2ndUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}