using System.Drawing;
namespace Game.Components
{
    public struct TorsoPart : IEquipment
    {
        public int Value { get; set; }
        public int Enchantment { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
    }
}
