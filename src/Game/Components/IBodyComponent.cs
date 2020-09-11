namespace Game.Components
{
    public interface IPartComponent
    {
        public int Value { get; set; }
        public int Enchantment { get; set; }
        public char[] Item { get; set; }
    }
}