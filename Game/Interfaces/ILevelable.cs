namespace EXCell
{
    public interface ILevelable
    {
        public static int NextLevel = 100;
        public int CurrentXP { get; }
        public int Level { get; }

        public void GainExpierence(int XP);
    }
}